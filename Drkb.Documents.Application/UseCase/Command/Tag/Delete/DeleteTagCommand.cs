using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Delete;

public record DeleteTagCommand(Guid Id) : IRequest<Result>;
