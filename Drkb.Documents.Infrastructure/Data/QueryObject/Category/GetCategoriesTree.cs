using Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;
using Drkb.Documents.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Drkb.Documents.Infrastructure.Data.QueryObject.Category;

public class GetCategoriesTree : IGetCategoriesTree
{
    private readonly DrkbDocumentsDbContext _context;

    public GetCategoriesTree(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoriesTreeDto>> ExecuteAsync(GetCategoriesTreeQuery query, CancellationToken cancellationToken = default)
    {
        // 1. Один запрос — все категории
        var allCategories = await _context.Categories
            .AsNoTracking()
            .Where(x=>x.IsDeleted == false)
            .Select(x=> new GetCategoriesTreeDto()
            {
                Id = x.Id,
                Title = x.Title,
                ParentCategoryId = x.ParentCategoryId,
            })
            .ToListAsync(cancellationToken);

        var lookup = allCategories.ToDictionary(x => x.Id);

        var roots = new List<GetCategoriesTreeDto>();
        
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