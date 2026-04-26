using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Domain.Entity;

public class CategoryAccessRule : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public AccessSubjectType SubjectType { get; set; }
    public Guid SubjectId { get; set; }

    public DocumentPermission Permission { get; set; }
}