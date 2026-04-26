using Drkb.Documents.Application.Interfaces.DataProvider;
using DrkbTaskManager.Domain.ResultObject;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Create;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Result>
{
    private readonly ICreateTagDataProvider _dataProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTagCommandHandler(ICreateTagDataProvider dataProvider, IUnitOfWork unitOfWork)
    {
        _dataProvider = dataProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.BadRequest("VALIDATION_ERROR", "Tag title is required");
        }

        var tag = new Domain.Entity.Tag
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            IsDeleted = false,
            DeletedAt = null,
            DocumentTags = new List<Domain.Entity.DocumentTag>()
        };

        await _dataProvider.AddAsync(tag, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
