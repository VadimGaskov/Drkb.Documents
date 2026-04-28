using Drkb.Documents.Application.UseCase.Command.Document.AssignTags;
using Drkb.Documents.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Tag;

public class AssignTagsAdapter : IAssignTagsPort
{
    private readonly DrkbDocumentsDbContext _context;

    public AssignTagsAdapter(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entity.Document?> GetDocumentWithTagsByIdAsync(Guid documentId)
    {
        return await _context.Documents.Include(x=>x.DocumentTags).FirstOrDefaultAsync(document => document.Id == documentId);
    }

    public async Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds)
    {
        return await _context.Tags.Where(x => tagIds.Contains(x.Id)).ToListAsync();
    }

    public async Task AddDocumentTagAsync(DocumentTag documentTag)
    {
        await _context.DocumentTags.AddAsync(documentTag);
    }

    public void RemoveDocumentTagAsync(DocumentTag documentTag)
    {
        _context.DocumentTags.Remove(documentTag);
    }
}