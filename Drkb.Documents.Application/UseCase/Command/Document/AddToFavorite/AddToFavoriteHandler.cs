using Drkb.Documents.Application.Interfaces.Authorization;
using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;
using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Command.Document.AddToFavorite;

public class AddToFavoriteHandler : IRequestHandler<AddToFavoriteCommand, Result> 
{
    private readonly IAddToFavoritePort _addToFavoritePort;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;
    
    public AddToFavoriteHandler(IAddToFavoritePort addToFavoritePort, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    {
        _addToFavoritePort = addToFavoritePort;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
    {
        var document = await _addToFavoritePort.GetDocumentByIdAsync(request.DocumentId);

        if (document == null)
        {
            return Result.BadRequest("Document not found");
        }

        await _addToFavoritePort.AddUserFavoriteDocumentAsync(new UserFavoriteDocument()
        {
            Id = Guid.NewGuid(),
            Document = document,
            DocumentId = document.Id,
            AddedAt = DateTime.UtcNow,
            UserId = _currentUserService.UserId
        });
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}