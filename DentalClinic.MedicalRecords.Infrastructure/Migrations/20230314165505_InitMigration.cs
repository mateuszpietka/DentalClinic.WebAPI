using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.MedicalRecords.Infrastructure.Migrations
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
                name: "PatientCards",
                schema: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientTeeth",
                schema: "medicalRecords",
                columns: table => new
                {
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    QuadrantCode = table.Column<int>(type: "int", nullable: false),
                    ToothNumber = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTeeth", x => new { x.PatientId, x.QuadrantCode, x.ToothNumber });
                });

            migrationBuilder.CreateTable(
                name: "PatientCardAnnotations",
                schema: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientCardId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCardAnnotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientCardAnnotations_PatientCards_PatientCardId",
                        column: x => x.PatientCardId,
                        principalSchema: "medicalRecords",
                        principalTable: "PatientCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientCardAnnotations_PatientCardId",
                schema: "medicalRecords",
                table: "PatientCardAnnotations",
                column: "PatientCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientCardAnnotations",
                schema: "medicalRecords");

            migrationBuilder.DropTable(
                name: "PatientTeeth",
                schema: "medicalRecords");

            migrationBuilder.DropTable(
                name: "PatientCards",
                schema: "medicalRecords");
        }
    }
}
