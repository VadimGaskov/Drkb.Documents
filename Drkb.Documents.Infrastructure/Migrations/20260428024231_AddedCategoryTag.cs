using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drkb.Documents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAccessRule_Categories_CategoryId",
                table: "CategoryAccessRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAccessRule",
                table: "CategoryAccessRule");

            migrationBuilder.RenameTable(
                name: "CategoryAccessRule",
                newName: "CategoryAccessRules");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAccessRule_CategoryId",
                table: "CategoryAccessRules",
                newName: "IX_CategoryAccessRules_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "TagScope",
                table: "Tags",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAccessRules",
                table: "CategoryAccessRules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CategoryTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTags_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentDepartmentAccesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDepartmentAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDepartmentAccesses_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentUserAccesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentUserAccesses_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTags_CategoryId",
                table: "CategoryTags",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTags_TagId",
                table: "CategoryTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDepartmentAccesses_DocumentId",
                table: "DocumentDepartmentAccesses",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUserAccesses_DocumentId",
                table: "DocumentUserAccesses",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteDocuments_DocumentId",
                table: "UserFavoriteDocuments",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAccessRules_Categories_CategoryId",
                table: "CategoryAccessRules",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAccessRules_Categories_CategoryId",
                table: "CategoryAccessRules");

            migrationBuilder.DropTable(
                name: "CategoryTags");

            migrationBuilder.DropTable(
                name: "DocumentDepartmentAccesses");

            migrationBuilder.DropTable(
                name: "DocumentUserAccesses");

            migrationBuilder.DropTable(
                name: "UserFavoriteDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAccessRules",
                table: "CategoryAccessRules");

            migrationBuilder.DropColumn(
                name: "TagScope",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "CategoryAccessRules",
                newName: "CategoryAccessRule");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAccessRules_CategoryId",
                table: "CategoryAccessRule",
                newName: "IX_CategoryAccessRule_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAccessRule",
                table: "CategoryAccessRule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAccessRule_Categories_CategoryId",
                table: "CategoryAccessRule",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
