using System.Text.Json.Serialization;

namespace Drkb.Documents.Application.DTOs;

public record BaseDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
}
