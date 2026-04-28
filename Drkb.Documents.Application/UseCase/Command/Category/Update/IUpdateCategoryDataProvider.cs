using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Application.UseCase.Command.Category.Update;

public interface IUpdateCategoryDataProvider : IDataProviderMarker
{
    public void Update(Domain.Entity.Category category);

    public Task<Domain.Entity.Category?> GetCategoryWithTagsByIdAsync(Guid id, CancellationToken cancellationToken);
    
    public Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds, CancellationToken cancellationToken);
    public void RemoveCategoryTag(CategoryTag categoryTag);
    public Task AddCategoryTagAsync(CategoryTag categoryTag, CancellationToken cancellationToken);
}
