using Drkb.Documents.Application.Interfaces.Audit;
using Drkb.Documents.Application.Interfaces.Audit.Document;
using Drkb.Documents.Application.Interfaces.Authorization;
using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Domain.Enum;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Create;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Result>
{
    private readonly ICreateDocumentDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IHistoryWriter<Domain.Entity.Document, DocumentHistoryChangeType> _historyWriter;
    public CreateDocumentCommandHandler(
        ICreateDocumentDataProvider dataProvider,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService, IHistoryWriter<Domain.Entity.Document, DocumentHistoryChangeType> historyWriter)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _historyWriter = historyWriter;
    }

    public async Task<Result> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR Document title is required");
        }

        if (request.CategoryId == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR Category id is required");
        }

        var tagsToAdd = await _dataProvider.GetTagsAsync(request.TagIds);

        if (tagsToAdd.Count != request.TagIds.Count)
        {
            return Result.BadRequest("Tag count mismatch");
        }
        
        var document = new Domain.Entity.Document
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            Description = request.Description?.Trim(),
            CategoryId = request.CategoryId,
            Status = DocumentStatus.Published,
            CreatedBy = _currentUserService.UserId,
            CreatedAt = DateTime.UtcNow,
        };

        await _dataProvider.AddAsync(document, cancellationToken);

        foreach (var tag in tagsToAdd)
        {
            await _dataProvider.AddDocumentTagAsync(new DocumentTag()
            {
                Id = Guid.NewGuid(),
                Document = document,
                DocumentId = document.Id,
                Tag = tag,
                TagId = tag.Id,
            });
        }
        
        await _historyWriter.CreateSnapshotAsync(
            document,
            DocumentHistoryChangeType.Created,
            _currentUserService.UserId, 
            cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
