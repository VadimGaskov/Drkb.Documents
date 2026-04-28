using Drkb.Documents.Application.Interfaces.Authorization;
using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.RemoveFromFavorite;

public class RemoveFromFavoriteHandler : IRequestHandler<RemoveFromFavoriteCommand, Result>
{
    private readonly IRemoveFromFavoritePort _removeFromFavoritePort;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveFromFavoriteHandler(
        IRemoveFromFavoritePort removeFromFavoritePort,
        ICurrentUserService currentUserService,
        IUnitOfWork unitOfWork)
    {
        _removeFromFavoritePort = removeFromFavoritePort;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveFromFavoriteCommand request, CancellationToken cancellationToken)
    {
        var document = await _removeFromFavoritePort.GetDocumentByIdAsync(request.DocumentId, cancellationToken);
        if (document is null)
        {
            return Result.BadRequest("Document not found");
        }

        var userFavoriteDocument = await _removeFromFavoritePort.GetUserFavoriteDocumentAsync(
            request.DocumentId,
            _currentUserService.UserId,
            cancellationToken);

        if (userFavoriteDocument is null)
        {
            return Result.BadRequest("Document is not in favorites");
        }

        _removeFromFavoritePort.RemoveUserFavoriteDocument(userFavoriteDocument);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
