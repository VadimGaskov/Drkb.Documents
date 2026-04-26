using Drkb.Documents.Application.UseCase.Command.Category.Delete;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Category;

public class DeleteCategoryDataProvider : IDeleteCategoryDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public DeleteCategoryDataProvider(DrkbDocumentsDbContext context)
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
