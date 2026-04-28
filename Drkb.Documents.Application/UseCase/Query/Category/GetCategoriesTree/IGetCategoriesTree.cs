using Drkb.Documents.Application.Interfaces.QueryObjects;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public interface IGetCategoriesTree : IQueryMarker, IQueryObject<GetCategoriesTreeQuery, List<GetCategoriesTreeDto>>
{
    
}