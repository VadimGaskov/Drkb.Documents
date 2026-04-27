using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public record GetAllCategoriesWithChildrenDto : BaseDto
{
    public string Title { get; set; }
    public List<DocumentDto> Documents { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public GetAllCategoriesWithChildrenDto? ParentCategory { get; set; }
    public List<GetAllCategoriesWithChildrenDto> Children { get; set; } = new();
}

public record DocumentDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}