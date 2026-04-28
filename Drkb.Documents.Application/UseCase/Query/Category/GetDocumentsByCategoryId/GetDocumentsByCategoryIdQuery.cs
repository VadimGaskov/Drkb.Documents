using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetDocumentsByCategoryId;

public record GetDocumentsByCategoryIdQuery(Guid CategoryId) : IRequest<Result<List<GetDocumentsByCategoryIdDto>>>;
