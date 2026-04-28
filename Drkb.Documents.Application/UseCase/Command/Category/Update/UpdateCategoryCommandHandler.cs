using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;
using Drkb.ResultObjects;
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
            return Result.BadRequest("VALIDATION_ERROR Category id is required");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR Category title is required");
        }
        
        var category = await _dataProvider.GetCategoryWithTagsByIdAsync(request.Id, cancellationToken);
        if (category is null || category.IsDeleted)
        {
            return Result.BadRequest("NOT_FOUND Category not found");
        }

        var newTags = await _dataProvider.GetTagsAsync(request.TagIds, cancellationToken);

        if (newTags.Count != request.TagIds.Count)
        {
            return Result.BadRequest("NOT_FOUND Tags found");
        }
        
        var currentTagIds = category.CategoryTags
            .Select(x => x.TagId)
            .ToHashSet();
        
        var categoryTagsToRemove = category.CategoryTags
            .Where(x => !request.TagIds.Contains(x.TagId))
            .ToList();

        var tagsToAdd = newTags
            .Where(x => !currentTagIds.Contains(x.Id))
            .ToList();

        foreach (var categoryTag in categoryTagsToRemove)
        {
            _dataProvider.RemoveCategoryTag(categoryTag);
        }

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
        
        category.Title = request.Title.Trim();
        category.ParentCategoryId = request.ParentCategoryId;

        _dataProvider.Update(category);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
