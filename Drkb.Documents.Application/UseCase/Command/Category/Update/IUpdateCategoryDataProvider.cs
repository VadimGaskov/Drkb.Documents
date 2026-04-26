using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Category.Update;

public interface IUpdateCategoryDataProvider : IUpdateDataProvider<Domain.Entity.Category>,
    IGetByIdDataProvider<Domain.Entity.Category>
{
}
