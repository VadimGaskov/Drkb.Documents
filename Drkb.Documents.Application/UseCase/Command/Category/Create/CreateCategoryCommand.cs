using Drkb.ResultObjects;
using MediatR;
namespace Drkb.Documents.Application.UseCase.Command.Category.Create;

public record CreateCategoryCommand(string Title, Guid? ParentCategoryId, List<Guid> TagIds) : IRequest<Result>;
