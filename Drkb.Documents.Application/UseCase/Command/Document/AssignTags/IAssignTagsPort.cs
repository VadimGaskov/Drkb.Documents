using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Application.UseCase.Command.Document.AssignTags;

public interface IAssignTagsPort : IDataProviderMarker
{
    public Task<Domain.Entity.Document?> GetDocumentWithTagsByIdAsync(Guid documentId);
    public Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds);
    public Task AddDocumentTagAsync(DocumentTag documentTag);
    public void RemoveDocumentTagAsync(DocumentTag documentTag);
}