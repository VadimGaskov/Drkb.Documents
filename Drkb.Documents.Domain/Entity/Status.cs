namespace Drkb.Documents.Domain.Entity;

public class Status : BaseEntity
{
    public string Title { get; set; }
    public List<Document> Documents { get; set; }
}