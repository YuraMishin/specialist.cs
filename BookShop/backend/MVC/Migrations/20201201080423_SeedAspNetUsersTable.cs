using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements SeedCouponsTable table seeder
  /// </summary>
  public partial class SeedAspNetUsersTable : Migration
  {
    /// <summary>
    /// Method seeds Books table
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "AspNetUsers",
        columns: new[]
        {
          "Id",
          "UserName",
          "NormalizedUserName",
          "Email",
          "NormalizedEmail",
          "EmailConfirmed",
          "PasswordHash",
          "SecurityStamp",
          "ConcurrencyStamp",
          "PhoneNumber",
          "PhoneNumberConfirmed",
          "TwoFactorEnabled",
          "LockoutEnd",
          "LockoutEnabled",
          "AccessFailedCount",
          "City",
          "Name",
          "PostalCode",
          "State",
          "StreetAddress",
          "Discriminator"
        },
        values: new object[]
        {
          Guid.NewGuid().ToString(),
          "admin@mail.ru",
          "ADMIN@MAIL.RU",
          "admin@mail.ru",
          "ADMIN@MAIL.RU",
          false,
          "AQAAAAEAACcQAAAAEGp985ti8w68abeaVk41JUTgzYrD+Xn3hhuVTdfv/F14S5/6iScuT6jzIj1rCxE0Xw==",
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
          "1",
          false,
          false,
          null,
          true,
          0,
          "1",
          "1",
          "1",
          "1",
          "1",
          "ApplicationUser"
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
        keyValue: "admin@mail.ru");
    }
  }
}
