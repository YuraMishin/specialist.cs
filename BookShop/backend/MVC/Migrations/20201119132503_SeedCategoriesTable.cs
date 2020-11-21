using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements Categories table seeder
  /// </summary>
  public partial class SeedCategoriesTable : Migration
  {
    /// <summary>
    /// Method seeds Categories table
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      // PostgreSQL
      // migrationBuilder.Sql(
      //   @"insert into ""Categories"" (""Name"") VALUES ('Adventures')");

      migrationBuilder.InsertData(
        table: "Categories",
        columns: new[] {"Name"},
        values: new object[] {"Adventures"});
    }

    /// <summary>
    /// Method removes current migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      // PostgreSQL
      // migrationBuilder
      //   .Sql(@"delete from ""Categories"" where ""Name"" in ('Adventures')");

      migrationBuilder.DeleteData(
        table: "Categories",
        keyColumn: "Name",
        keyValue: "Adventures");
    }
  }
}
