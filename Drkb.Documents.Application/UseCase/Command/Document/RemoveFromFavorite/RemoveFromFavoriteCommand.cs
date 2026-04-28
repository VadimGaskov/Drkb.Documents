using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.RemoveFromFavorite;

public record RemoveFromFavoriteCommand(Guid DocumentId) : IRequest<Result>;
