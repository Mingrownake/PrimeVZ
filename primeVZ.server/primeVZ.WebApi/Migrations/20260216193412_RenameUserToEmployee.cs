using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeVZ.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Users",
                newName: "LastName"
            );

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Employees");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
