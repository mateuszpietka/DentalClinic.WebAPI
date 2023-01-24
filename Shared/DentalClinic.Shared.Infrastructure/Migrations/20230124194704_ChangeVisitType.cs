using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVisitType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Hours" },
                values: new object[] { "Tooth root canal treatment", 2 });

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Prosthetics");

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Putting on an orthodontic appliance");

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Hours" },
                values: new object[] { "Tooth extraction", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Hours" },
                values: new object[] { "Control visit", 1 });

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Tooth root canal treatment");

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Prosthetics");

            migrationBuilder.UpdateData(
                table: "VisitTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Hours" },
                values: new object[] { "Putting on an orthodontic appliance", 2 });

            migrationBuilder.InsertData(
                table: "VisitTypes",
                columns: new[] { "Id", "Description", "Hours" },
                values: new object[] { 6, "Tooth extraction", 1 });
        }
    }
}
