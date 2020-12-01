using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements AddCouponsTable migration
  /// </summary>
  public partial class AddCouponsTable : Migration
  {
    /// <summary>
    /// Method performs migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Coupons",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
            .Annotation("Npgsql:ValueGenerationStrategy",
              NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          Name = table.Column<string>(maxLength: 50, nullable: false),
          CouponType = table.Column<string>(nullable: false),
          Discount = table.Column<double>(nullable: false),
          MinimumAmount = table.Column<double>(nullable: false),
          Picture = table.Column<byte[]>(nullable: true),
          IsActive = table.Column<bool>(nullable: false)
        },
        constraints: table => { table.PrimaryKey("PK_Coupons", x => x.Id); });
    }

    /// <summary>
    /// Method rollbacks migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Coupons");
    }
  }
}
