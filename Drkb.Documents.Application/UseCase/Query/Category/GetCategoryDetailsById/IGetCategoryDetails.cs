using Drkb.Documents.Application.Interfaces.QueryObjects;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;

public interface IGetCategoryDetails : IQueryMarker, IQueryObject<GetCategoryDetailsQuery, GetCategoryDetailsDto?>
{
}
