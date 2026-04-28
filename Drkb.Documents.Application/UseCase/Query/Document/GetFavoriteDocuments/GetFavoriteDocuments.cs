using Drkb.Documents.Application.Interfaces.QueryObjects;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetAllByUserDocuments;

public interface GetFavoriteDocuments : IQueryMarker, IQueryObject<GetFavoriteDocumentsQuery, List<GetFavoriteDocumentsDto>>
{
    
}
