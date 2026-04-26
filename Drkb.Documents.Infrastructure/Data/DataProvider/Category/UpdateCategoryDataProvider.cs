using Drkb.Documents.Application.UseCase.Command.Category.Update;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Category;

public class UpdateCategoryDataProvider : IUpdateCategoryDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public UpdateCategoryDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public void Update(Domain.Entity.Category entity)
    {
        _context.Categories.Update(entity);
    }

    public async Task<Domain.Entity.Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
