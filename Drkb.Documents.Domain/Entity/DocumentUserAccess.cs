namespace Drkb.Documents.Domain.Entity;

public class DocumentUserAccess : BaseEntity
{
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }

    public Guid UserId { get; set; }
}