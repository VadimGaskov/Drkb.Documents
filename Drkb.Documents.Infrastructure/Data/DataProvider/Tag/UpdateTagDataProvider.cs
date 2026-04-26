using Drkb.Documents.Application.UseCase.Command.Tag.Update;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Tag;

public class UpdateTagDataProvider : IUpdateTagDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public UpdateTagDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public void Update(Domain.Entity.Tag entity)
    {
        _context.Tags.Update(entity);
    }

    public async Task<Domain.Entity.Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Tags.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
