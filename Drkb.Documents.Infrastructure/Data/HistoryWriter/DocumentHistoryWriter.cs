using Drkb.Documents.Application.Interfaces.Audit;
using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Domain.Enum;
using Drkb.Documents.Infrastructure.Data.AuditEntities;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.HistoryWriter;

public class DocumentHistoryWriter : IHistoryWriter<Document, DocumentHistoryChangeType>
{
    private readonly DrkbDocumentsDbContext _context;

    public DocumentHistoryWriter(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task CreateSnapshotAsync(
        Document entity,
        DocumentHistoryChangeType changeType,
        Guid changedByUserId,
        CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        var lastHistory = await _context.DocumentHistories
            .SingleOrDefaultAsync(
                x => x.DocumentId == entity.Id && x.ValidTo == null,
                cancellationToken);

        var nextVersion = lastHistory is null ? 1 : lastHistory.Version + 1;

        if (lastHistory is not null)
        {
            lastHistory.ValidTo = now;
        }

        var category = entity.Category ?? await _context.Categories.SingleAsync(x => x.Id == entity.CategoryId, cancellationToken: cancellationToken);
        
        var documentTags = await _context.DocumentTags
            .Include(x => x.Tag)
            .Where(x => x.DocumentId == entity.Id)
            .ToListAsync(cancellationToken);
        
        var documentHistory = new DocumentHistory
        {
            Id = Guid.NewGuid(),

            DocumentId = entity.Id,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,

            Version = nextVersion,
            ValidFrom = now,
            ValidTo = null,

            DocumentStatus = entity.Status,
            ChangedByUserId = changedByUserId,
            ChangeType = changeType,

            CategoryId = entity.CategoryId,
            Category = category,
            CategoryTitle = category.Title,
            DocumentTagsHistories = documentTags.Select(x => new DocumentTagHistory
            {
                Id = Guid.NewGuid(),
                TagId = x.TagId,
                TagTitle = x.Tag.Title
            }).ToList()
        };

        await _context.DocumentHistories.AddAsync(documentHistory, cancellationToken);
    }
}