using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class CategoryRoleAccess : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public string RoleName { get; set; } = null!;
    public CategoryPermission CategoryPermission { get; set; }
}