using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Category.Delete;

public record DeleteCategoryCommand(Guid Id) : IRequest<Result>;
