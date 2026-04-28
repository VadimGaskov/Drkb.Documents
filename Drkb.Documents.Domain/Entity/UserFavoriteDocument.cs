namespace Drkb.Documents.Domain.Entity;

public class UserFavoriteDocument : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid DocumentId { get; set; }
    public Document Document { get; set; }

    public DateTime AddedAt { get; set; }
}