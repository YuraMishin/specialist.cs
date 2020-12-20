using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace EFPostgrsql.App.Migrations
{
  public partial class AddCategoriesTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Categories",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Categories", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Categories");
    }
  }
}
