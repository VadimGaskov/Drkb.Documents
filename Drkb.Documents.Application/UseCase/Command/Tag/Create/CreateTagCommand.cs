using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Create;

public record CreateTagCommand(string Title) : IRequest<Result>;
