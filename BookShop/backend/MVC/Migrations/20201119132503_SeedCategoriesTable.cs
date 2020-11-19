using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
  public partial class SeedCategoriesTable : Migration
  {
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
