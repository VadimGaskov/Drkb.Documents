namespace Drkb.Documents.Permissions;

public sealed record PermissionDefinition(
    string Code,
    string DisplayName,
    string? Description = null
);