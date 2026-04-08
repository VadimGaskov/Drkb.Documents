namespace Drkb.Documents.Domain.Entity;

public class Document : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Category Category { get; set; }
    public Status Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<DocumentTag> DocumentTags { get; set; }
}