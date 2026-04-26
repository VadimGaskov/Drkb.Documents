using Drkb.Documents.Application.Interfaces.DataProvider;
using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Update;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Result>
{
    private readonly IUpdateTagDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTagCommandHandler(IUpdateTagDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR", "Tag id is required");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR", "Tag title is required");
        }

        var tag = await _dataProvider.GetByIdAsync(request.Id, cancellationToken);
        if (tag is null || tag.IsDeleted)
        {
            return Result.BadRequest("NOT_FOUND", "Tag not found");
        }

        tag.Title = request.Title.Trim();

        _dataProvider.Update(tag);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
