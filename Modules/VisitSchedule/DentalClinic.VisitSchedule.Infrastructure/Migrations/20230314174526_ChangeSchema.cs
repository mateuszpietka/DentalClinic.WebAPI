using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.VisitSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "visitSchedule");

            migrationBuilder.RenameTable(
                name: "VisitTypes",
                schema: "medicalRecords",
                newName: "VisitTypes",
                newSchema: "visitSchedule");

            migrationBuilder.RenameTable(
                name: "Visits",
                schema: "medicalRecords",
                newName: "Visits",
                newSchema: "visitSchedule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "medicalRecords");

            migrationBuilder.RenameTable(
                name: "VisitTypes",
                schema: "visitSchedule",
                newName: "VisitTypes",
                newSchema: "medicalRecords");

            migrationBuilder.RenameTable(
                name: "Visits",
                schema: "visitSchedule",
                newName: "Visits",
                newSchema: "medicalRecords");
        }
    }
}
