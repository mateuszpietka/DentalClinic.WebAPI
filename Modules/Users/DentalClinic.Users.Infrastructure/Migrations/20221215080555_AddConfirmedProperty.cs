using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfirmedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                schema: "users",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IsConfirmed", "PasswordHash" },
                values: new object[] { true, "AQAAAAEAACcQAAAAEIItCVnzxUOBST/AUvsJ+LRyypCYDf8HOpENB2vr8JBNMtyJ6eESlg3TrwTajdPqBQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                schema: "users",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "pass");
        }
    }
}
