using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;

public record GetCategoryDetailsDto : BaseDto
{
    public string Title { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public List<GetCategoryDetailsDto> Children { get; set; } = new();
    public List<GetCategoryWithChildrenByIdDocumentDto> Documents { get; set; } = new();
    public List<GetCategoryWithChildrenByIdTagDto> Tags { get; set; } = new();
}

public record GetCategoryWithChildrenByIdDocumentDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<GetCategoryWithChildrenByIdTagDto> Tags { get; set; } = new();
}

public record GetCategoryWithChildrenByIdTagDto : BaseDto
{
    public string Title { get; set; }
}
