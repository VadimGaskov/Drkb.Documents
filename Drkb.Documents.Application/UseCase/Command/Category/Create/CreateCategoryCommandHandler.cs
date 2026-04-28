using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;
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

        var tagsToAdd = await _dataProvider.GetTagsAsync(request.TagIds, cancellationToken);

        if (tagsToAdd.Count != request.TagIds.Count)
        {
            return Result.BadRequest("VALIDATION_ERROR Tag IDs are invalid");
        }
        
        var category = new Domain.Entity.Category
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            IsDeleted = false,
            DeletedAt = null,
            ParentCategoryId = request.ParentCategoryId
        };

        await _dataProvider.AddCategoryAsync(category);

        foreach (var tag in tagsToAdd)
        {
            await _dataProvider.AddCategoryTagAsync(new CategoryTag()
            {
                Id = Guid.NewGuid(),
                Category = category,
                CategoryId = category.Id,
                Tag = tag,
                TagId = tag.Id
            }, cancellationToken);
        }
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
