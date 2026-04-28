using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetFavoriteDocuments;

public record GetFavoriteDocumentsDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public CategoryDto? Category { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<GetFavoriteDocumentsTagDto> Tags { get; set; } = new();
}

public record CategoryDto : BaseDto
{
    public string Title { get; set; }
}

public record GetFavoriteDocumentsTagDto : BaseDto
{
    public string Title { get; set; }
}
