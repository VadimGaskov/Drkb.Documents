using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Document.Delete;

public interface IDeleteDocumentDataProvider : IUpdateDataProvider<Domain.Entity.Document>,
    IGetByIdDataProvider<Domain.Entity.Document>
{
}
