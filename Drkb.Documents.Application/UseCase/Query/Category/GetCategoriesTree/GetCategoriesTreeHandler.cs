using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public class GetCategoriesTreeHandler : IRequestHandler<GetCategoriesTreeQuery, Result<List<GetCategoriesTreeDto>>>
{
    private readonly IGetCategoriesTree _getCategoriesTree;

    public GetCategoriesTreeHandler(IGetCategoriesTree getCategoriesTree)
    {
        _getCategoriesTree = getCategoriesTree;
    }

    public async Task<Result<List<GetCategoriesTreeDto>>> Handle(GetCategoriesTreeQuery request, CancellationToken cancellationToken)
    {
        var categoriesWithChildren = await _getCategoriesTree.ExecuteAsync(request, cancellationToken);

        return Result<List<GetCategoriesTreeDto>>.Success(categoriesWithChildren);
    }
}