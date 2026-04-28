using Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;
using Drkb.Documents.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.QueryObject.Category;

public class GetCategoryDetails : IGetCategoryDetails
{
    private readonly DrkbDocumentsDbContext _context;

    public GetCategoryDetails(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryDetailsDto?> ExecuteAsync(GetCategoryDetailsQuery query, CancellationToken cancellationToken = default)
    {
        var allCategories = await _context.Categories
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .Select(x => new GetCategoryDetailsDto
            {
                Id = x.Id,
                Title = x.Title,
                ParentCategoryId = x.ParentCategoryId,
                Tags = x.CategoryTags
                    .Where(ct => !ct.Tag.IsDeleted)
                    .Select(ct => new GetCategoryDetailsDtoTagDto
                    {
                        Id = ct.TagId,
                        Title = ct.Tag.Title
                    })
                    .ToList(),
            })
            .ToListAsync(cancellationToken);

        var lookup = allCategories.ToDictionary(x => x.Id);
        
        foreach (var category in allCategories)
        {
            if (category.ParentCategoryId is Guid parentId && lookup.TryGetValue(parentId, out var parent))
            {
                parent.Children.Add(category);
            }
        }

        return lookup.GetValueOrDefault(query.CategoryId);
    }
}
