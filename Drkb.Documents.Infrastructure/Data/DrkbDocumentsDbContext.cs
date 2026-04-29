using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Infrastructure.Data.AuditEntities;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data;

public class DrkbDocumentsDbContext : DbContext
{
    public DrkbDocumentsDbContext(DbContextOptions<DrkbDocumentsDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryTag> CategoryTags { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentTag> DocumentTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<UserFavoriteDocument> UserFavoriteDocuments { get; set; }
    
    
    
    public DbSet<DocumentHistory> DocumentHistories { get; set; }
    public DbSet<DocumentTagHistory> DocumentTagHistories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<DocumentHistory>()
            .ToTable("document_history", "audit");
        modelBuilder.Entity<DocumentTagHistory>()
            .ToTable("document_tag_history", "audit");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureAssemblyMarker).Assembly);
    }
}