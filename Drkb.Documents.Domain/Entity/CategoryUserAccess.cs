using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class CategoryUserAccess : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Guid UserId { get; set; }
    public CategoryPermission CategoryPermission { get; set; }
}