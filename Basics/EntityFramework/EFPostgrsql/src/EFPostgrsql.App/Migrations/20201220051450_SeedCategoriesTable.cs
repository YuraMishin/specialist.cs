using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EFPostgrsql.App.Migrations
{
  public partial class SeedCategoriesTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "Categories",
        columns: new[] { "CreatedOn", "UpdatedOn", "Name" },
        values: new object[,]
        {
              {DateTime.Now, DateTime.Now, "Adventure"},
              {DateTime.Now, DateTime.Now,"Fantasy"}
        });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
         table: "Categories",
         keyColumn: "Name",
         keyValue: "Adventure");

      migrationBuilder.DeleteData(
        table: "Categories",
        keyColumn: "Name",
        keyValue: "Fantasy");
    }
  }
}
