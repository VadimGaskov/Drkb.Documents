using Drkb.Documents.Application.UseCase.Command.Document.RemoveFromFavorite;
using Drkb.Documents.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Document;

public class RemoveFromFavoriteAdapter : IRemoveFromFavoritePort
{
    private readonly DrkbDocumentsDbContext _context;

    public RemoveFromFavoriteAdapter(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entity.Document?> GetDocumentByIdAsync(Guid documentId, CancellationToken cancellationToken = default)
    {
        return await _context.Documents.FirstOrDefaultAsync(x => x.Id == documentId, cancellationToken);
    }

    public async Task<UserFavoriteDocument?> GetUserFavoriteDocumentAsync(Guid documentId, Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.UserFavoriteDocuments
            .FirstOrDefaultAsync(x => x.DocumentId == documentId && x.UserId == userId, cancellationToken);
    }

    public void RemoveUserFavoriteDocument(UserFavoriteDocument userFavoriteDocument)
    {
        _context.UserFavoriteDocuments.Remove(userFavoriteDocument);
    }
}
