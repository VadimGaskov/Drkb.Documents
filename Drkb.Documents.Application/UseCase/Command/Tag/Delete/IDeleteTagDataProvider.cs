using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Delete;

public interface IDeleteTagDataProvider : IUpdateDataProvider<Domain.Entity.Tag>,
    IGetByIdDataProvider<Domain.Entity.Tag>
{
}
