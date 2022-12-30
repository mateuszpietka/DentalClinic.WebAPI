using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientTeeth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientTeeth",
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
                    table.ForeignKey(
                        name: "FK_PatientTeeth_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientTeeth");
        }
    }
}
