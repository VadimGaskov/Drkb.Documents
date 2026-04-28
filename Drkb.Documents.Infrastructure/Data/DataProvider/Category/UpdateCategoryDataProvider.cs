using Drkb.Documents.Application.UseCase.Command.Category.Update;
using Drkb.Documents.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Category;

public class UpdateCategoryDataProvider : IUpdateCategoryDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public UpdateCategoryDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public void Update(Domain.Entity.Category category)
    {
        _context.Categories.Update(category);
    }

    public async Task<Domain.Entity.Category?> GetCategoryWithTagsByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Categories.Include(x=>x.CategoryTags).FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
    }

    public async Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds, CancellationToken cancellationToken)
    {
        return await _context.Tags.Where(x=> tagIds.Contains(x.Id)).ToListAsync(cancellationToken);
    }

    public void RemoveCategoryTag(CategoryTag categoryTag)
    {
        _context.CategoryTags.Remove(categoryTag);
    }

    public async Task AddCategoryTagAsync(CategoryTag categoryTag, CancellationToken cancellationToken)
    {
        await _context.CategoryTags.AddAsync(categoryTag, cancellationToken);
    }
}