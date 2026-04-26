using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drkb.Documents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccessRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagTitle",
                schema: "audit",
                table: "document_tag_history",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryTitle",
                schema: "audit",
                table: "document_history",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ChangeType",
                schema: "audit",
                table: "document_history",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryAccessRule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectType = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Permission = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAccessRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryAccessRule_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAccessRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectType = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Permission = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAccessRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAccessRules_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAccessRule_CategoryId",
                table: "CategoryAccessRule",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAccessRules_DocumentId",
                table: "DocumentAccessRules",
                column: "DocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryAccessRule");

            migrationBuilder.DropTable(
                name: "DocumentAccessRules");

            migrationBuilder.DropColumn(
                name: "TagTitle",
                schema: "audit",
                table: "document_tag_history");

            migrationBuilder.DropColumn(
                name: "CategoryTitle",
                schema: "audit",
                table: "document_history");

            migrationBuilder.DropColumn(
                name: "ChangeType",
                schema: "audit",
                table: "document_history");
        }
    }
}
