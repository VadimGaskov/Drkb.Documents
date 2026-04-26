using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Infrastructure.Data.AuditEntities;

public class DocumentHistory
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public string? Description { get; set; }
    public Category Category { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int Version { get; set; }
    public Guid ChangedByUserId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public List<DocumentTagHistory> DocumentTagsHistories { get; set; }
}