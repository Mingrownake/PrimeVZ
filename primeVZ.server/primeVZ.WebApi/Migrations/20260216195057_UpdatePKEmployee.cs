using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeVZ.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePKEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
