using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Infrastructure.Data;

public class EFUnitOfWork: IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //TODO прописать реализацию
        throw new NotImplementedException();
    }
}