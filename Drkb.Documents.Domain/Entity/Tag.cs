using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class Tag : BaseEntity
{
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
    public TagScope TagScope { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<DocumentTag> DocumentTags { get; set; }
    public List<CategoryTag> CategoryTags { get; set; } = new();
}