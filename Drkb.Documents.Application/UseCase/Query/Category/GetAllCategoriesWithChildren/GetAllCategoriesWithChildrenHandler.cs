using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public class GetAllCategoriesWithChildrenHandler : IRequestHandler<GetAllCategoriesWithChildrenQuery, Result<List<GetAllCategoriesWithChildrenDto>>>
{
    private readonly IGetAllCategoriesWithChildren _getAllCategoriesWithChildren;

    public GetAllCategoriesWithChildrenHandler(IGetAllCategoriesWithChildren getAllCategoriesWithChildren)
    {
        _getAllCategoriesWithChildren = getAllCategoriesWithChildren;
    }

    public async Task<Result<List<GetAllCategoriesWithChildrenDto>>> Handle(GetAllCategoriesWithChildrenQuery request, CancellationToken cancellationToken)
    {
        var categoriesWithChildren = await _getAllCategoriesWithChildren.ExecuteAsync(request, cancellationToken);

        return Result<List<GetAllCategoriesWithChildrenDto>>.Success(categoriesWithChildren);
    }
}