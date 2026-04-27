using Drkb.Documents.Domain.Enum;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.Update;

public record UpdateDocumentCommand(Guid Id, string Title, string? Description, Guid CategoryId, DocumentStatus Status)
    : IRequest<Result>;
