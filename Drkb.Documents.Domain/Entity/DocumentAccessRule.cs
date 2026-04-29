using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class DocumentAccessRule : BaseEntity
{
    public Guid DocumentId { get; set; }
    
    public DocumentPermission Permission { get; set; }
    public Guid UserId { get; set; }
}