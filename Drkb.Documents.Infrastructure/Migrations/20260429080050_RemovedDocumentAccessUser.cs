using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drkb.Documents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDocumentAccessUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentUserAccesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUserAccesses_DocumentId",
                table: "DocumentUserAccesses",
                column: "DocumentId");
        }
    }
}
