using Drkb.Documents.Application.DTOs;
using Drkb.Documents.Domain.Enum;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetAllByUserDocuments;

public record GetFavoriteDocumentsDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsFavorite { get; set; }
    public List<GetAllByUserDocumentsTagDto> Tags { get; set; } = new();
}

public record GetAllByUserDocumentsTagDto : BaseDto
{
    public string Title { get; set; }
}
