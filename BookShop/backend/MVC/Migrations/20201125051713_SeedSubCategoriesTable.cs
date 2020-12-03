using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements SubCategories table seeder
  /// </summary>
  public partial class SeedSubCategoriesTable : Migration
  {
    /// <summary>
    /// Method seeds SubCategories table
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "SubCategories",
        columns: new[] {"Name", "CategoryId"},
        values: new object[,]
        {
          {"Space", 1},
          {"Magic", 2}
        });
    }

    /// <summary>
    /// Method removes current migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
        table: "SubCategories",
        keyColumn: "Name",
        keyValue: "Space");
      migrationBuilder.DeleteData(
        table: "SubCategories",
        keyColumn: "Name",
        keyValue: "Magic");
    }
  }
}
