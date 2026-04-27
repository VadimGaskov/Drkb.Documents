using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Delete;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Result>
{
    private readonly IDeleteTagDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTagCommandHandler(IDeleteTagDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.BadRequest("VALIDATION_ERROR Tag id is required");
        }

        var tag = await _dataProvider.GetByIdAsync(request.Id, cancellationToken);
        
        if (tag is null || tag.IsDeleted)
        {
            return Result.BadRequest("NOT_FOUND Tag not found");
        }

        tag.IsDeleted = true;
        tag.DeletedAt = DateTime.UtcNow;

        _dataProvider.Update(tag);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
