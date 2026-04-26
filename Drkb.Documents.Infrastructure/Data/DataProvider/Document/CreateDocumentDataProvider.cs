using Drkb.Documents.Application.UseCase.Command.Document.Create;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Document;

public class CreateDocumentDataProvider : ICreateDocumentDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public CreateDocumentDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Domain.Entity.Document entity, CancellationToken cancellationToken = default)
    {
        await _context.Documents.AddAsync(entity, cancellationToken);
    }
}
