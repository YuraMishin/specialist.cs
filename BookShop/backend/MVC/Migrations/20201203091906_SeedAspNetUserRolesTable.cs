using Microsoft.EntityFrameworkCore.Migrations;
using MVC.Utility;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements AspNetUserRoles table seeder
  /// </summary>
  public partial class SeedAspNetUserRolesTable : Migration
  {
    /// <summary>
    /// Method seeds AspNetUserRoles table
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql(
        $@"insert into ""AspNetUserRoles"" (""UserId"", ""RoleId"")
VALUES ((select ""Id"" from ""AspNetUsers"" where ""UserName"" = '{SD.AdminEmail}'),
       (select ""Id"" from ""AspNetRoles"" where ""Name"" = '{SD.ManagerUser}'))");

      migrationBuilder.Sql(
        $@"insert into ""AspNetUserRoles"" (""UserId"", ""RoleId"")
VALUES ((select ""Id"" from ""AspNetUsers"" where ""UserName"" = '{SD.UserEmail}'),
       (select ""Id"" from ""AspNetRoles"" where ""Name"" = '{SD.CustomerEndUser}'))");
    }


    /// <summary>
    /// Method removes current migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql($@"DELETE FROM ""AspNetUserRoles""");
    }
  }
}
