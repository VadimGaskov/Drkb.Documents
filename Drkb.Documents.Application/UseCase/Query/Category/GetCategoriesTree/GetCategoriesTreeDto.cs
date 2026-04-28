using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public record GetCategoriesTreeDto : BaseDto
{
    public string Title { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public List<GetCategoriesTreeDto> Children { get; set; } = new();
}
