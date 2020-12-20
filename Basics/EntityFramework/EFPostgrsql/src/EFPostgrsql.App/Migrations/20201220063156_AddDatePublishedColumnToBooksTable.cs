using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPostgrsql.App.Migrations
{
    public partial class AddDatePublishedColumnToBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Books",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Books");
        }
    }
}
