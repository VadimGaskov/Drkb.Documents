using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class CategoryPermission : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public PermissionSubject PermissionSubject { get; set; }
    public Guid PermissionSubjectId { get; set; }

    public PermissionType Permission { get; set; }  // ← enum вместо string

    // true = запрет (Deny beats Allow)
    public bool IsDeny { get; set; } = false;

    // false = не каскадировать на дочерние категории и документы
    public bool IsInheritable { get; set; } = true;
}