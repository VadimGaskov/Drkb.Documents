using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Application.UseCase.Command.Document.RemoveFromFavorite;

public interface IRemoveFromFavoritePort : IDataProviderMarker
{
    public Task<Domain.Entity.Document?> GetDocumentByIdAsync(Guid documentId, CancellationToken cancellationToken = default);
    public Task<UserFavoriteDocument?> GetUserFavoriteDocumentAsync(Guid documentId, Guid userId, CancellationToken cancellationToken = default);
    public void RemoveUserFavoriteDocument(UserFavoriteDocument userFavoriteDocument);
}
