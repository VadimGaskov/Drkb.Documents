namespace Drkb.Documents.Domain.Entity;

public class Tag : BaseEntity
{
    public string Title { get; set; }
    public List<DocumentTag> DocumentTags { get; set; }
}