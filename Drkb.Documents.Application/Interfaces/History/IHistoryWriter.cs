using Drkb.Documents.Application.Interfaces.Audit.Document;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.Interfaces.Audit;

public interface IHistoryWriter<in TEntity, in TChangeType>
    where TEntity : class
    where TChangeType : struct, Enum
{
    Task CreateSnapshotAsync(
        TEntity entity,
        TChangeType changeType,
        Guid changedByUserId,
        CancellationToken cancellationToken = default);
}