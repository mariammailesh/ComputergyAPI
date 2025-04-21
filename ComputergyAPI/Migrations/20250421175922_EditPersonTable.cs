using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputergyAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogedIn",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "Persons",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogedIn",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "Persons");
        }
    }
}
