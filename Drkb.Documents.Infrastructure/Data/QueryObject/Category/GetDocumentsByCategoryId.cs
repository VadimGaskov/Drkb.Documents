using Drkb.Documents.Application.UseCase.Query.Category.GetDocumentsByCategoryId;
using Drkb.Documents.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Drkb.Documents.Infrastructure.Data.QueryObject.Category;

public class GetDocumentsByCategoryId : IGetDocumentsByCategoryId
{
    private readonly DrkbDocumentsDbContext _context;

    public GetDocumentsByCategoryId(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetDocumentsByCategoryIdDto>> ExecuteAsync(GetDocumentsByCategoryIdQuery query, CancellationToken cancellationToken = default)
    {
        return await _context.Documents
            .AsNoTracking()
            .Where(x => x.CategoryId == query.CategoryId && x.Status != DocumentStatus.Deleted)
            .Select(x => new GetDocumentsByCategoryIdDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                CreatedBy = x.CreatedBy,
                CreatedAt = x.CreatedAt,
                Tags = x.DocumentTags
                    .Where(t => !t.Tag.IsDeleted)
                    .Select(t => new GetDocumentsByCategoryIdTagDto
                    {
                        Id = t.TagId,
                        Title = t.Tag.Title
                    })
                    .ToList()
            })
            .ToListAsync(cancellationToken);
    }
}
