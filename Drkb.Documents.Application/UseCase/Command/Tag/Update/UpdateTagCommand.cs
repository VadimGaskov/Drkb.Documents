using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Update;

public record UpdateTagCommand(Guid Id, string Title) : IRequest<Result>;
