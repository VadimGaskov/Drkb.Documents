using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetDocumentsByCategoryId;

public record GetDocumentsByCategoryIdDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<GetDocumentsByCategoryIdTagDto> Tags { get; set; } = new();
}

public record GetDocumentsByCategoryIdTagDto : BaseDto
{
    public string Title { get; set; }
}
