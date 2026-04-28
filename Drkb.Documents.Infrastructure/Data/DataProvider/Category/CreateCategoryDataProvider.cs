using Drkb.Documents.Application.UseCase.Command.Category.Create;
using Drkb.Documents.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Category;

public class CreateCategoryDataProvider : ICreateCategoryDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public CreateCategoryDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task AddCategoryAsync(Domain.Entity.Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds, CancellationToken cancellationToken)
    {
        return await _context.Tags.Where(x => tagIds.Contains(x.Id)).ToListAsync(cancellationToken);
    }

    public async Task AddCategoryTagAsync(CategoryTag categoryTag, CancellationToken cancellationToken)
    {
        await _context.CategoryTags.AddAsync(categoryTag,cancellationToken);
    }
}
