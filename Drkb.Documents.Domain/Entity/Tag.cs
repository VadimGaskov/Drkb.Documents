namespace Drkb.Documents.Domain.Entity;

public class Tag : BaseEntity
{
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<DocumentTag> DocumentTags { get; set; }
}