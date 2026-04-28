using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Category.Update;

public record UpdateCategoryCommand(Guid Id, string Title, Guid? ParentCategoryId, List<Guid> TagIds) : IRequest<Result>;
