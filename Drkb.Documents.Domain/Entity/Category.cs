namespace Drkb.Documents.Domain.Entity;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public List<Document> Documents { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public List<Category> Children { get; set; }
    public List<CategoryAccessRule> AccessRules { get; set; } 
}