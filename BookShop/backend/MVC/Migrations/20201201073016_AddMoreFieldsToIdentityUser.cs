﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
  /// <summary>
  /// Class implements AddMoreFieldsToIdentityUser migration
  /// </summary>
  public partial class AddMoreFieldsToIdentityUser : Migration
  {
    /// <summary>
    /// Method performs migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
        name: "Name",
        table: "AspNetUserTokens",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "character varying(128)",
        oldMaxLength: 128);

      migrationBuilder.AlterColumn<string>(
        name: "LoginProvider",
        table: "AspNetUserTokens",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "character varying(128)",
        oldMaxLength: 128);

      migrationBuilder.AddColumn<string>(
        name: "City",
        table: "AspNetUsers",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "Name",
        table: "AspNetUsers",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "PostalCode",
        table: "AspNetUsers",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "State",
        table: "AspNetUsers",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "StreetAddress",
        table: "AspNetUsers",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "Discriminator",
        table: "AspNetUsers",
        nullable: false,
        defaultValue: "");

      migrationBuilder.AlterColumn<string>(
        name: "ProviderKey",
        table: "AspNetUserLogins",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "character varying(128)",
        oldMaxLength: 128);

      migrationBuilder.AlterColumn<string>(
        name: "LoginProvider",
        table: "AspNetUserLogins",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "character varying(128)",
        oldMaxLength: 128);
    }

    /// <summary>
    /// Method rollbacks migration
    /// </summary>
    /// <param name="migrationBuilder">MigrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "City",
        table: "AspNetUsers");

      migrationBuilder.DropColumn(
        name: "Name",
        table: "AspNetUsers");

      migrationBuilder.DropColumn(
        name: "PostalCode",
        table: "AspNetUsers");

      migrationBuilder.DropColumn(
        name: "State",
        table: "AspNetUsers");

      migrationBuilder.DropColumn(
        name: "StreetAddress",
        table: "AspNetUsers");

      migrationBuilder.DropColumn(
        name: "Discriminator",
        table: "AspNetUsers");

      migrationBuilder.AlterColumn<string>(
        name: "Name",
        table: "AspNetUserTokens",
        type: "character varying(128)",
        maxLength: 128,
        nullable: false,
        oldClrType: typeof(string));

      migrationBuilder.AlterColumn<string>(
        name: "LoginProvider",
        table: "AspNetUserTokens",
        type: "character varying(128)",
        maxLength: 128,
        nullable: false,
        oldClrType: typeof(string));

      migrationBuilder.AlterColumn<string>(
        name: "ProviderKey",
        table: "AspNetUserLogins",
        type: "character varying(128)",
        maxLength: 128,
        nullable: false,
        oldClrType: typeof(string));

      migrationBuilder.AlterColumn<string>(
        name: "LoginProvider",
        table: "AspNetUserLogins",
        type: "character varying(128)",
        maxLength: 128,
        nullable: false,
        oldClrType: typeof(string));
    }
  }
}
