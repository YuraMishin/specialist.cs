using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNetCore.Migrations
{
  public partial class SeedBooksTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("insert into Books (Name) values ('Book1')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder
        .Sql("delete from Books where Name in ('Book1')");
    }
  }
}
