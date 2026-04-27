using Drkb.Documents.Application.Interfaces.QueryObjects;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public interface IGetAllCategoriesWithChildren : IQueryMarker, IQueryObject<GetAllCategoriesWithChildrenQuery, List<GetAllCategoriesWithChildrenDto>>
{
    
}