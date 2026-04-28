using Drkb.Documents.Application.Interfaces.QueryObjects;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetFavoriteDocuments;

public interface IGetFavoriteDocuments : IQueryMarker, IQueryObject<GetFavoriteDocumentsQuery, List<GetFavoriteDocumentsDto>>
{
    
}
