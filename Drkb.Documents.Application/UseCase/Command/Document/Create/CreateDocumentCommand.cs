using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Create;

public record CreateDocumentCommand(string Title, string? Description, Guid CategoryId) : IRequest<Result>;
