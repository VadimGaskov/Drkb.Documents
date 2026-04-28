using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.AssignTags;

public class AssignTagsHandler : IRequestHandler<AssignTagsCommand, Result>
{
    private readonly IAssignTagsPort _assignTagsPort;
    private readonly IUnitOfWork _unitOfWork;
    public AssignTagsHandler(IAssignTagsPort assignTagsPort, IUnitOfWork unitOfWork)
    {
        _assignTagsPort = assignTagsPort;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AssignTagsCommand request, CancellationToken cancellationToken)
    {
        var document = await _assignTagsPort.GetDocumentWithTagsByIdAsync(request.DocumentId);

        if (document == null)
            return Result.BadRequest("Document not found");
        
        var tags = await _assignTagsPort.GetTagsAsync(request.TagIds);

        if (tags.Count != request.TagIds.Count)
            return Result.BadRequest("Some tags not found");

        var currentTagIds = document.DocumentTags
            .Select(x => x.TagId)
            .ToHashSet();
        
        var documentTagsToRemove = document.DocumentTags
            .Where(x => !request.TagIds.Contains(x.TagId))
            .ToList();

        var tagsToAdd = tags
            .Where(x => !currentTagIds.Contains(x.Id))
            .ToList();

        foreach (var documentTag in documentTagsToRemove)
        {
            _assignTagsPort.RemoveDocumentTagAsync(documentTag);
        }

        foreach (var tag in tagsToAdd)
        {
            await _assignTagsPort.AddDocumentTagAsync(new DocumentTag
            {
                Id = Guid.NewGuid(),
                DocumentId = document.Id,
                TagId = tag.Id
            });
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}