using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements AddSubCategoriesTable migration
  /// </summary>
  public partial class AddSubCategoriesTable : Migration
  {
    /// <summary>
    /// Method performs migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "SubCategories",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
            .Annotation("Npgsql:ValueGenerationStrategy",
              NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          Name = table.Column<string>(maxLength: 50, nullable: false),
          CategoryId = table.Column<int>(nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_SubCategories", x => x.Id);
          table.ForeignKey(
            name: "FK_SubCategories_Categories_CategoryId",
            column: x => x.CategoryId,
            principalTable: "Categories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateIndex(
        name: "IX_SubCategories_CategoryId",
        table: "SubCategories",
        column: "CategoryId");
    }

    /// <summary>
    /// Method rollbacks migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "SubCategories");
    }
  }
}
