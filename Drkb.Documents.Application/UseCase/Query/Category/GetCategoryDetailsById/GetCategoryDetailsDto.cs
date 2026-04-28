using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;

public record GetCategoryDetailsDto : BaseDto
{
    public string Title { get; set; }
    public Guid? ParentCategoryId { get; set; }
    //TODO Пока не понятно надо это тут или нет
    public List<GetCategoryDetailsDto> Children { get; set; } = new();
    public List<GetCategoryDetailsDtoTagDto> Tags { get; set; } = new();
}


public record GetCategoryDetailsDtoTagDto : BaseDto
{
    public string Title { get; set; }
}
