using Drkb.Documents.Application.UseCase.Command.Tag.Create;

namespace Drkb.Documents.Infrastructure.Data.DataProvider.Tag;

public class CreateTagDataProvider : ICreateTagDataProvider
{
    private readonly DrkbDocumentsDbContext _context;

    public CreateTagDataProvider(DrkbDocumentsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Domain.Entity.Tag entity, CancellationToken cancellationToken = default)
    {
        await _context.Tags.AddAsync(entity, cancellationToken);
    }
}
