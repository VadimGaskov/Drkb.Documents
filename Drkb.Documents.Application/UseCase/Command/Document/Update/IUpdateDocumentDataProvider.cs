using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Document.Update;

public interface IUpdateDocumentDataProvider : IUpdateDataProvider<Domain.Entity.Document>,
    IGetByIdDataProvider<Domain.Entity.Document>
{
}
