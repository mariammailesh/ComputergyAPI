using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputergyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeToPerson : Migration
    {
        /// <inheritdoc />
        /// 

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Persons");
        }
    }
}
