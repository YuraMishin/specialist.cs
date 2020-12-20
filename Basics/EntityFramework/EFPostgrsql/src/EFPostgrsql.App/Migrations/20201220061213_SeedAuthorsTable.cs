using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EFPostgrsql.App.Migrations
{
  public partial class SeedAuthorsTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "Authors",
        columns: new[] { "CreatedOn", "UpdatedOn", "Name" },
        values: new object[,]
        {
              {DateTime.Now, DateTime.Now, "Mishin Yury"}

        });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
        table: "Authors",
        keyColumn: "Name",
        keyValue: "Mishin Yury");
    }
  }
}
