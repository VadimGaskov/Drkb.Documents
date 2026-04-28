using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;

public record GetCategoryDetailsQuery(Guid CategoryId) : IRequest<Result<GetCategoryDetailsDto>>;
