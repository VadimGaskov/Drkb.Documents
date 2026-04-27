using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.AssignTags;

public class AssignTagsHandler : IRequestHandler<AssignTagsCommand, Result>
{
    private readonly IAssignTagsPort _assignTagsPort;

    public AssignTagsHandler(IAssignTagsPort assignTagsPort)
    {
        _assignTagsPort = assignTagsPort;
    }

    public async Task<Result> Handle(AssignTagsCommand request, CancellationToken cancellationToken)
    {
        if (!await _assignTagsPort.CheckIfDocumentExitstsAsync(request.DocumentId))
        {
            return Result.BadRequest("Документ не существует");
        }

        
    }
}