using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public record GetAllCategoriesWithChildrenQuery() : IRequest<Result<List<GetAllCategoriesWithChildrenDto>>>;