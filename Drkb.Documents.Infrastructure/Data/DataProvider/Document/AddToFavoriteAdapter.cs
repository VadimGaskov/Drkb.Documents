using Drkb.Documents.Application.UseCase.Command.Document.AddToFavorite;
using Drkb.Documents.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Document;

public class AddToFavoriteAdapter : IAddToFavoritePort
{
    private readonly DrkbDocumentsDbContext _context;

    public AddToFavoriteAdapter(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entity.Document?> GetDocumentByIdAsync(Guid documentId)
    {
        return await _context.Documents.FirstOrDefaultAsync(x=>x.Id == documentId);
    }

    public async Task AddUserFavoriteDocumentAsync(UserFavoriteDocument userFavoriteDocument)
    {
        await _context.UserFavoriteDocuments.AddAsync(userFavoriteDocument);
    }
}