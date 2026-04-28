using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetFavoriteDocuments;

public record GetFavoriteDocumentsQuery() : IRequest<Result<List<GetFavoriteDocumentsDto>>>;
