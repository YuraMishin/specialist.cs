using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EFPostgrsql.App.Migrations
{
  public partial class SeedBooksTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "Books",
        columns: new[]
        {
          "CreatedOn",
          "UpdatedOn",
          "Title",
          "Description",
          "CategoryId",
          "BookAge",
          "FullPrice",
          "AuthorId"
        },
        values: new object[,]
        {
              {
                DateTime.Now,
                DateTime.Now,
                "T1",
                "D1",
                1,
                0,
                10,
                1
              }

        });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
        table: "Books",
        keyColumn: "Title",
        keyValue: "T1");
    }
  }
}
