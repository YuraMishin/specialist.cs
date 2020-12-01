using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements AddCategoriesTable migration
  /// </summary>
  public partial class AddCategoriesTable : Migration
  {
    /// <summary>
    /// Method performs migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Categories",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
            .Annotation("Npgsql:ValueGenerationStrategy",
              NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          Name = table.Column<string>(maxLength: 50, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Categories", x => x.Id);
        });
    }

    /// <summary>
    /// Method rollbacks migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Categories");
    }
  }
}
