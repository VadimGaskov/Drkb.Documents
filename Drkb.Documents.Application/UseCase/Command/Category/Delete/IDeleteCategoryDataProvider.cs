using Drkb.Documents.Application.Interfaces.DataProvider;

namespace Drkb.Documents.Application.UseCase.Command.Category.Delete;

public interface IDeleteCategoryDataProvider : IUpdateDataProvider<Domain.Entity.Category>,
    IGetByIdDataProvider<Domain.Entity.Category>
{
}
