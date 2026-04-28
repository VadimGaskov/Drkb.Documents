using Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;
using Drkb.Documents.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Drkb.Documents.Infrastructure.Data.QueryObject.Category;

public class GetAllCategoriesWithChildren : IGetAllCategoriesWithChildren
{
    private readonly DrkbDocumentsDbContext _context;

    public GetAllCategoriesWithChildren(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllCategoriesWithChildrenDto>> ExecuteAsync(GetAllCategoriesWithChildrenQuery query, CancellationToken cancellationToken = default)
    {
        // 1. Один запрос — все категории
        var allCategories = await _context.Categories
            .AsNoTracking()
            .Where(x=>x.IsDeleted == false)
            .Select(x=> new GetAllCategoriesWithChildrenDto()
            {
                Id = x.Id,
                Title = x.Title,
                ParentCategoryId = x.ParentCategoryId,
            })
            .ToListAsync(cancellationToken);

        var lookup = allCategories.ToDictionary(x => x.Id);

        var roots = new List<GetAllCategoriesWithChildrenDto>();
        
        foreach (var category in allCategories)
        {
            if (category.ParentCategoryId is null)
            {
                roots.Add(category);
            }
            else if (lookup.TryGetValue(category.ParentCategoryId.Value, out var parent))
            {
                parent.Children.Add(category);
            }
        }
        
        return roots;
    }
}