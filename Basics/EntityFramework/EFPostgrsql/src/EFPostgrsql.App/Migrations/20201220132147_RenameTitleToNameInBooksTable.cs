using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPostgrsql.App.Migrations
{
    public partial class RenameTitleToNameInBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Title");
        }
    }
}
