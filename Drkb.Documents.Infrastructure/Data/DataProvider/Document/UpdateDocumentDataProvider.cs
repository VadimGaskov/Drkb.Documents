using Drkb.Documents.Application.UseCase.Command.Document.Update;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Document;

public class UpdateDocumentDataProvider : IUpdateDocumentDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public UpdateDocumentDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public void Update(Domain.Entity.Document entity)
    {
        _context.Documents.Update(entity);
    }

    public async Task<Domain.Entity.Document?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Documents.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }
}
