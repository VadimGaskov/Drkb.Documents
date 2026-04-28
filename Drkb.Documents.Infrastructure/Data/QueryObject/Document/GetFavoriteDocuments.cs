using Drkb.Documents.Application.Interfaces.Authorization;
using Drkb.Documents.Application.UseCase.Query.Document.GetAllByUserDocuments;
using Drkb.Documents.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.QueryObject.Document;

public class GetFavoriteDocuments : GetFavoriteDocuments
{
    private readonly DrkbDocumentsDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetFavoriteDocuments(DrkbDocumentsDbContext context, ICurrentUserService currentUserService) : base(context, currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<List<GetFavoriteDocumentsDto>> ExecuteAsync(GetFavoriteDocumentsQuery query, CancellationToken cancellationToken = default)
    {
        var userId = _currentUserService.UserId;

        return await _context.Documents
            .AsNoTracking()
            .Where(x => x.CreatedBy == userId && x.Status != DocumentStatus.Deleted)
            .Select(x => new GetFavoriteDocumentsDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                Status = x.Status,
                CreatedBy = x.CreatedBy,
                CreatedAt = x.CreatedAt,
                IsFavorite = x.UserFavoriteDocuments.Any(f => f.UserId == userId),
                Tags = x.DocumentTags.Select(t => new GetAllByUserDocumentsTagDto
                {
                    Id = t.TagId,
                    Title = t.Tag.Title
                }).ToList()
            })
            .ToListAsync(cancellationToken);
    }
}
