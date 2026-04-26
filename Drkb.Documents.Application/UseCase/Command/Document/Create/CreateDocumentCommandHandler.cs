using Drkb.Documents.Application.Interfaces.Authorization;
using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Enum;
using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Create;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Result>
{
    private readonly ICreateDocumentDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public CreateDocumentCommandHandler(
        ICreateDocumentDataProvider dataProvider,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Result> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR", "Document title is required");
        }

        if (request.CategoryId == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR", "Category id is required");
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
            DeletedAt = null,
            DocumentTags = new List<Domain.Entity.DocumentTag>()
        };

        await _dataProvider.AddAsync(document, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
