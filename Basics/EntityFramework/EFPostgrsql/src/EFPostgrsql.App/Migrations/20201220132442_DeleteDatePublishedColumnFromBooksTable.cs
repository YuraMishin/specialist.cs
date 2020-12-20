using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPostgrsql.App.Migrations
{
    public partial class DeleteDatePublishedColumnFromBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Books",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
