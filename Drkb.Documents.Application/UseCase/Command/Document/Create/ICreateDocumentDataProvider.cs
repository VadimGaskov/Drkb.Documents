using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Document.Create;

public interface ICreateDocumentDataProvider : IAddDataProvider<Domain.Entity.Document>
{
}
