using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Infrastructure.Data.AuditEntities;

public class DocumentTagHistory
{
    public Guid Id { get; set; }

    public Guid DocumentHistoryId { get; set; }
    public DocumentHistory DocumentHistory { get; set; } = null!;

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}