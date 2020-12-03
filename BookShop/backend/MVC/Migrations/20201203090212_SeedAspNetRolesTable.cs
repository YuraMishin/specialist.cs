using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MVC.Utility;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements AspNetRoles table seeder
  /// </summary>
  public partial class SeedAspNetRolesTable : Migration
  {
    /// <summary>
    /// Method seeds AspNetRoles table
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[]
        {
          "Id",
          "Name",
          "NormalizedName",
          "ConcurrencyStamp"
        },
        values: new object[,]
        {
          {
            Guid.NewGuid().ToString(),
            SD.ManagerUser,
            SD.ManagerUser.ToUpper(),
            Guid.NewGuid().ToString()
          },
          {
            Guid.NewGuid().ToString(),
            SD.CustomerEndUser,
            SD.CustomerEndUser.ToUpper(),
            Guid.NewGuid().ToString()
          },
          {
            Guid.NewGuid().ToString(),
            SD.FrontDeskUser,
            SD.FrontDeskUser.ToUpper(),
            Guid.NewGuid().ToString()
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
        table: "AspNetUsers",
        keyColumn: "UserName",
        keyValue: SD.FrontDeskUser);
      migrationBuilder.DeleteData(
        table: "AspNetUsers",
        keyColumn: "UserName",
        keyValue: SD.CustomerEndUser);
      migrationBuilder.DeleteData(
        table: "AspNetUsers",
        keyColumn: "UserName",
        keyValue: SD.ManagerUser);
    }
  }
}
