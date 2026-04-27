using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Category.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result>
{
    private readonly ICreateCategoryDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICreateCategoryDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR Category title is required");
        }

        var category = new Domain.Entity.Category
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            IsDeleted = false,
            DeletedAt = null,
            ParentCategoryId = request.ParentCategoryId
        };

        await _dataProvider.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
