using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Entity;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;

public record GetAllCategoriesWithChildrenDto : BaseDto
{
    public string Title { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public List<GetAllCategoriesWithChildrenDto> Children { get; set; } = new();
}

public record DocumentDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<TagDto> Tags { get; set; } = new(); // ✅ сразу теги, без промежуточного DocumentTagDto
}

public record TagDto : BaseDto
{
    public string Title { get; set; }
    
}