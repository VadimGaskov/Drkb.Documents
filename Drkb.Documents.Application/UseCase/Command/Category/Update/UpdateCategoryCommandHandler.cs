using Drkb.Documents.Application.Interfaces.DataProvider;
using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Category.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    private readonly IUpdateCategoryDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUpdateCategoryDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR", "Category id is required");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR", "Category title is required");
        }

        var category = await _dataProvider.GetByIdAsync(request.Id, cancellationToken);
        if (category is null || category.IsDeleted)
        {
            return Result.BadRequest("NOT_FOUND", "Category not found");
        }

        category.Title = request.Title.Trim();
        category.ParentCategoryId = request.ParentCategoryId;

        _dataProvider.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
