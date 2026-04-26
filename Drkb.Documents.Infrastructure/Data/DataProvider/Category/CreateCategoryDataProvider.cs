using Drkb.Documents.Application.UseCase.Command.Category.Create;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Category;

public class CreateCategoryDataProvider : ICreateCategoryDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public CreateCategoryDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Domain.Entity.Category entity, CancellationToken cancellationToken = default)
    {
        await _context.Categories.AddAsync(entity, cancellationToken);
    }
}
