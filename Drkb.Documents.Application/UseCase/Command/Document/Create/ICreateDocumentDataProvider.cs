using Drkb.Documents.Application.Interfaces.DataProvider;
using Drkb.Documents.Domain.Entity;

namespace Drkb.Documents.Application.UseCase.Command.Document.Create;

public interface ICreateDocumentDataProvider : IAddDataProvider<Domain.Entity.Document>
{
    public Task<List<Domain.Entity.Tag>> GetTagsAsync(List<Guid> tagIds);
    public Task AddDocumentTagAsync(DocumentTag documentTag);
}
