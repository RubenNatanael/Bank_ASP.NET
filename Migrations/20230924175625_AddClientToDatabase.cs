using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankProject.Migrations
{
    /// <inheritdoc />
    public partial class AddClientToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.AddColumn<int>(
                name: "_Founds",
                table: "Banks",
                type: "int",
                nullable: false,
                defaultValue: 0);
           */

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Founds = table.Column<int>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropColumn(
                name: "_Founds",
                table: "Banks");
        }
    }
}
