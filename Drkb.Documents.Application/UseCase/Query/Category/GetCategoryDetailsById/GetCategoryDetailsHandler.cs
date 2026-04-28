using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;

public class GetCategoryDetailsHandler : IRequestHandler<GetCategoryDetailsQuery, Result<GetCategoryDetailsDto>>
{
    private readonly IGetCategoryDetails _getCategoryDetails;

    public GetCategoryDetailsHandler(IGetCategoryDetails getCategoryDetails)
    {
        _getCategoryDetails = getCategoryDetails;
    }

    public async Task<Result<GetCategoryDetailsDto>> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await _getCategoryDetails.ExecuteAsync(request, cancellationToken);
        if (category is null)
        {
            return Result<GetCategoryDetailsDto>.BadRequest("Category not found.");
        }

        return Result<GetCategoryDetailsDto>.Success(category);
    }
}
