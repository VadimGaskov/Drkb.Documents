using Drkb.Documents.Application.UseCase.Command.Category.Create;
using Drkb.Documents.Domain.Entity;

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

    public Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddCategoryTagAsync(CategoryTag categoryTag, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
