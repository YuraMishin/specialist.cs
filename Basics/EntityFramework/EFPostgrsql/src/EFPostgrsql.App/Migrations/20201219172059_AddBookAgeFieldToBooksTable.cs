using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPostgrsql.App.Migrations
{
    public partial class AddBookAgeFieldToBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookAge",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAge",
                table: "Books");
        }
    }
}
