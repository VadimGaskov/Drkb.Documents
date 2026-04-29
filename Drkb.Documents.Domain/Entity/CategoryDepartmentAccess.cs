using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class CategoryDepartmentAccess : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Guid DepartmentId { get; set; }
    public CategoryPermission CategoryPermission { get; set; }
}