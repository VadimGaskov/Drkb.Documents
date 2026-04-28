using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Application.UseCase.Command.Document.AddToFavorite;

public interface IAddToFavoritePort : IDataProviderMarker
{
    public Task<Domain.Entity.Document?> GetDocumentByIdAsync(Guid documentId);
    public Task AddUserFavoriteDocumentAsync(UserFavoriteDocument userFavoriteDocument);
}