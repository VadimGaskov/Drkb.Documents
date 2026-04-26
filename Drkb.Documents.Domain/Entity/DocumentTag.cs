namespace Drkb.Documents.Domain.Entity;

public class DocumentTag : BaseEntity
{
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }
    
    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}