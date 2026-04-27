using Drkb.Documents.Application.UseCase.Command.Document.AssignTags;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Tag;

public class AssignTagsAdapter : IAssignTagsPort
{
    private readonly DrkbDocumentsDbContext _context;

    public AssignTagsAdapter(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckIfDocumentExitstsAsync(Guid documentId)
    {
        return await _context.Documents.AnyAsync(x=>x.Id == documentId);
    }

    public async Task AddTags(List<Guid> tags)
    {
        await _context.Tags.AddRangeAsync(tags);
    }
}