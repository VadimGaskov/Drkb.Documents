using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Tag.Update;

public interface IUpdateTagDataProvider : IUpdateDataProvider<Domain.Entity.Tag>,
    IGetByIdDataProvider<Domain.Entity.Tag>
{
}
