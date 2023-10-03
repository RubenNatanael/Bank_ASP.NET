using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankProject.Migrations
{
    /// <inheritdoc />
    public partial class AddBank2ToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Founds",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "_Password",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Password",
                table: "Banks");

            migrationBuilder.AlterColumn<string>(
                name: "Founds",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
