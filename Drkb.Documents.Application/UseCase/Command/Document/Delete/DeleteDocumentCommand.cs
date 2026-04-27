using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Delete;

public record DeleteDocumentCommand(Guid Id) : IRequest<Result>;
