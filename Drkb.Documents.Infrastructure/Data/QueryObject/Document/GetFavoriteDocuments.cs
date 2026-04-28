using Drkb.Documents.Application.Interfaces.Authorization;
using Drkb.Documents.Application.UseCase.Query.Document.GetFavoriteDocuments;
using Drkb.Documents.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.QueryObject.Document;

public class GetFavoriteDocuments : IGetFavoriteDocuments
{
    private readonly DrkbDocumentsDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetFavoriteDocuments(DrkbDocumentsDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<List<GetFavoriteDocumentsDto>> ExecuteAsync(GetFavoriteDocumentsQuery query, CancellationToken cancellationToken = default)
    {
        var userId = _currentUserService.UserId;

        return await _context.Documents
            .AsNoTracking()
            .Where(x => x.Status != DocumentStatus.Deleted && x.UserFavoriteDocuments.Any(f => f.UserId == userId))
            .Select(x => new GetFavoriteDocumentsDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                Category = x.Category == null ? null : new CategoryDto()
                {
                    Id = x.Category.Id,
                    Title = x.Category.Title,
                } ,
                CreatedBy = x.CreatedBy,
                CreatedAt = x.CreatedAt,
                Tags = x.DocumentTags.Select(t => new GetFavoriteDocumentsTagDto
                {
                    Id = t.TagId,
                    Title = t.Tag.Title
                }).ToList()
            })
            .ToListAsync(cancellationToken);
    }
}
