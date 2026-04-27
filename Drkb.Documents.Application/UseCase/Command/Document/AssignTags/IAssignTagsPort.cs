using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Document.AssignTags;

public interface IAssignTagsPort : IDataProviderMarker
{
    public Task<bool> CheckIfDocumentExitstsAsync(Guid documentId);
    public Task AddTags(List<Guid> tags);
}