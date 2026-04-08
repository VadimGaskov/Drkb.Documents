namespace Drkb.Documents.Domain.Entity;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public List<Document> Documents { get; set; }
    public Category? ParentCategory { get; set; }
    public List<Category> Children { get; set; }
}