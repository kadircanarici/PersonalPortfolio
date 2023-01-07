using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "skills",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "skills",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "colomn",
                table: "skills",
                newName: "Column");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "skills",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "skills",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Column",
                table: "skills",
                newName: "colomn");
        }
    }
}
