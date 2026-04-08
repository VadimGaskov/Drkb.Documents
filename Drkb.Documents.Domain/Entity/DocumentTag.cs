namespace Drkb.Documents.Domain.Entity;

public class DocumentTag : BaseEntity
{
    public Document Document { get; set; }
    public Tag Tag { get; set; }
}