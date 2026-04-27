using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Category.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
{
    private readonly IDeleteCategoryDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IDeleteCategoryDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR Category id is required");
        }

        var category = await _dataProvider.GetByIdAsync(request.Id, cancellationToken);
        if (category is null || category.IsDeleted)
        {
            return Result.BadRequest("NOT_FOUND Category not found");
        }

        category.IsDeleted = true;
        category.DeletedAt = DateTime.UtcNow;

        _dataProvider.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
