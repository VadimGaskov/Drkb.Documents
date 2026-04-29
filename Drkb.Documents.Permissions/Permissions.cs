namespace Drkb.Documents.Permissions;

public static class Permissions
{
    public const string ViewDocuments = "documents.document.view";
    public const string CreateDocuments = "documents.document.create";
    public const string EditDocuments = "documents.document.edit";
    public const string DeleteDocuments = "documents.document.delete";
    public const string RestoreDocuments = "documents.document.restore";

    public const string ManageCategories = "documents.category.manage";
    public const string ManageTags = "documents.tag.manage";

    public const string ManageDocumentAccess = "documents.access.manage";

    public const string ViewDocumentHistory = "documents.history.view";
    public const string ManageFavoriteDocuments = "documents.favorite.manage";

    public static readonly IReadOnlyCollection<PermissionDefinition> All =
    [
        new(
            ViewDocuments,
            "Просмотр документов",
            "Позволяет просматривать список документов и их содержимое"
        ),
        new(
            CreateDocuments,
            "Создание документов",
            "Позволяет создавать новые документы"
        ),
        new(
            EditDocuments,
            "Редактирование документов",
            "Позволяет изменять содержимое и свойства документов"
        ),
        new(
            DeleteDocuments,
            "Удаление документов",
            "Позволяет удалять документы (мягкое удаление)"
        ),
        new(
            RestoreDocuments,
            "Восстановление документов",
            "Позволяет восстанавливать ранее удалённые документы"
        ),
        new(
            ManageCategories,
            "Управление категориями",
            "Позволяет создавать, изменять и удалять категории документов"
        ),
        new(
            ManageTags,
            "Управление тегами",
            "Позволяет создавать, изменять и удалять теги документов"
        ),
        new(
            ManageDocumentAccess,
            "Управление доступом к документам",
            "Позволяет настраивать права доступа пользователей к документам"
        ),
        new(
            ViewDocumentHistory,
            "Просмотр истории документов",
            "Позволяет просматривать историю изменений документов"
        ),
        new(
            ManageFavoriteDocuments,
            "Избранные документы",
            "Позволяет добавлять и удалять документы из избранного"
        )
    ];
}