using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Doctor");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Receptionist");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Lekarz");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Pracownik recepcji");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Pacjent");
        }
    }
}
