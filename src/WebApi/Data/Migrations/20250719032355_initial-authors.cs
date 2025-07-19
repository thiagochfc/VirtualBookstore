using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualBookstore.WebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialauthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UUID", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", maxLength: 400, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                    table.UniqueConstraint("AK_authors_Email", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
