using Drkb.Documents.Application.Interfaces.QueryObjects;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetDocumentsByCategoryId;

public interface IGetDocumentsByCategoryId : IQueryMarker, IQueryObject<GetDocumentsByCategoryIdQuery, List<GetDocumentsByCategoryIdDto>>
{
}
