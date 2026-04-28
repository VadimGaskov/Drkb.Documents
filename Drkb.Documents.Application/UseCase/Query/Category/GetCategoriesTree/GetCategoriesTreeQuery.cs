using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public record GetCategoriesTreeQuery() : IRequest<Result<List<GetCategoriesTreeDto>>>;