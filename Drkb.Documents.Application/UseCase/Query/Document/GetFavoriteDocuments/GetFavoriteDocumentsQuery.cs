using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetAllByUserDocuments;

public record GetFavoriteDocumentsQuery() : IRequest<Result<List<GetFavoriteDocumentsDto>>>;
