using Drkb.Documents.Application.UseCase.Command.Document.Create;
using Drkb.Documents.Domain.Entity;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds)
    {
        return await _context.Tags.Where(x => tagIds.Contains(x.Id)).ToListAsync();
    }

    public async Task AddDocumentTagAsync(DocumentTag documentTag)
    {
        await _context.DocumentTags.AddAsync(documentTag);
    }
}
