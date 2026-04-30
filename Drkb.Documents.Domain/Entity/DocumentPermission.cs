using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class DocumentPermission : BaseEntity
{
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }

    public PermissionSubject PermissionSubject { get; set; }
    public Guid PermissionSubjectId { get; set; }

    public PermissionType Permission { get; set; }  // ← enum вместо string
    public bool IsDeny { get; set; } = false;
}