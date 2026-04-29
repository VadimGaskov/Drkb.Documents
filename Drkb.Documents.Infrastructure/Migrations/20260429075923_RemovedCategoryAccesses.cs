using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drkb.Documents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCategoryAccesses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryAccessRules");

            migrationBuilder.DropTable(
                name: "DocumentAccessRules");

            migrationBuilder.DropTable(
                name: "DocumentDepartmentAccesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryAccessRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Permission = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAccessRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryAccessRules_Categories_CategoryId",
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
                    Permission = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectType = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAccessRules_CategoryId",
                table: "CategoryAccessRules",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAccessRules_DocumentId",
                table: "DocumentAccessRules",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDepartmentAccesses_DocumentId",
                table: "DocumentDepartmentAccesses",
                column: "DocumentId");
        }
    }
}
