using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Enum;
using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Update;

public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, Result>
{
    private readonly IUpdateDocumentDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDocumentCommandHandler(IUpdateDocumentDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR", "Document id is required");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR", "Document title is required");
        }

        if (request.CategoryId == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR", "Category id is required");
        }

        var document = await _dataProvider.GetByIdAsync(request.Id, cancellationToken);
        if (document is null || document.DeletedAt is not null || document.Status == DocumentStatus.Deleted)
        {
            return Result.BadRequest("NOT_FOUND", "Document not found");
        }

        document.Title = request.Title.Trim();
        document.Description = request.Description?.Trim();
        document.CategoryId = request.CategoryId;
        document.Status = request.Status;

        _dataProvider.Update(document);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
