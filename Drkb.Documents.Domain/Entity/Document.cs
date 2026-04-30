using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class Document : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<DocumentTag> DocumentTags { get; set; } = new List<DocumentTag>();
    public List<DocumentPermission> Permissions { get; set; } = new();
    public List<UserFavoriteDocument> UserFavoriteDocuments { get; set; } = new List<UserFavoriteDocument>();
}