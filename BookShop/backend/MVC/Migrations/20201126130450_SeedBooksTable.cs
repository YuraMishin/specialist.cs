﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements Books table seeder
  /// </summary>
  public partial class SeedBooksTable : Migration
  {
    /// <summary>
    /// Method seeds Books table
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "Books",
        columns: new[]
        {
          "Name",
          "Description",
          "Age",
          "Image",
          "CategoryId",
          "SubCategoryId",
          "Price"
        },
        values: new object[,]
        {
          {
            "Book1",
            "Desc1",
            "1",
            @"\img\1.png",
            1,
            1,
            100
          },
          {
            "Book2",
            "Desc2",
            "0",
            @"\img\1.png",
            2,
            2,
            1
          }
        });
    }

    /// <summary>
    /// Method removes current migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
        table: "Books",
        keyColumn: "Name",
        keyValue: "Book1");
      migrationBuilder.DeleteData(
        table: "Books",
        keyColumn: "Name",
        keyValue: "Book2");
    }
  }
}
