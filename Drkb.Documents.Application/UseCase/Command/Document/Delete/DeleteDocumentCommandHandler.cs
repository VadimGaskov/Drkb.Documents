using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Enum;
using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Delete;

public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, Result>
{
    private readonly IDeleteDocumentDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentCommandHandler(IDeleteDocumentDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR", "Document id is required");
        }

        var document = await _dataProvider.GetByIdAsync(request.Id, cancellationToken);
        if (document is null || document.DeletedAt is not null || document.Status == DocumentStatus.Deleted)
        {
            return Result.BadRequest("NOT_FOUND", "Document not found");
        }

        document.Status = DocumentStatus.Deleted;
        document.DeletedAt = DateTime.UtcNow;

        _dataProvider.Update(document);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
