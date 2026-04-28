using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Application.UseCase.Command.Category.Create;

public interface ICreateCategoryDataProvider : IDataProviderMarker
{
    public Task AddCategoryAsync(Domain.Entity.Category category);
    public Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds, CancellationToken cancellationToken);
    public Task AddCategoryTagAsync(CategoryTag categoryTag, CancellationToken cancellationToken);
}
