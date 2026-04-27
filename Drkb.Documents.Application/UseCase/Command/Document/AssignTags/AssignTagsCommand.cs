using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.AssignTags;

public record AssignTagsCommand : IRequest<Result>
{
    public Guid DocumentId { get; init; }
    public List<Guid> Tags { get; init; }
}