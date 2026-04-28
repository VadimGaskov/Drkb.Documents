namespace Drkb.Documents.Domain.Entity;

public class CategoryTag : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}