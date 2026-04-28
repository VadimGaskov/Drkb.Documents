using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.AddToFavorite;

public record AddToFavoriteCommand(Guid DocumentId) : IRequest<Result>;