namespace Drkb.Documents.Domain.Entity;

public class DocumentDepartmentAccess : BaseEntity
{
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }

    public Guid DepartmentId { get; set; }
}