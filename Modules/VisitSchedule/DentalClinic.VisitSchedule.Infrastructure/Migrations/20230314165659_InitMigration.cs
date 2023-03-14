using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DentalClinic.VisitSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "medicalRecords");

            migrationBuilder.CreateTable(
                name: "VisitTypes",
                schema: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                schema: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFirstVisit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    VisitTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_VisitTypes_VisitTypeId",
                        column: x => x.VisitTypeId,
                        principalSchema: "medicalRecords",
                        principalTable: "VisitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "medicalRecords",
                table: "VisitTypes",
                columns: new[] { "Id", "Description", "Hours" },
                values: new object[,]
                {
                    { 1, "Control visit", 1 },
                    { 2, "Tooth root canal treatment", 2 },
                    { 3, "Prosthetics", 2 },
                    { 4, "Putting on an orthodontic appliance", 2 },
                    { 5, "Tooth extraction", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                schema: "medicalRecords",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                schema: "medicalRecords",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitTypeId",
                schema: "medicalRecords",
                table: "Visits",
                column: "VisitTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits",
                schema: "medicalRecords");

            migrationBuilder.DropTable(
                name: "VisitTypes",
                schema: "medicalRecords");
        }
    }
}
