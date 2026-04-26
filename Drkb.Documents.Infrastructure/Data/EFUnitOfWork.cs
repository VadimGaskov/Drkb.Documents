using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Infrastructure.Data;

public class EFUnitOfWork: IUnitOfWork
{
    private readonly DrkbDocumentsDbContext _context;

    public EFUnitOfWork(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}