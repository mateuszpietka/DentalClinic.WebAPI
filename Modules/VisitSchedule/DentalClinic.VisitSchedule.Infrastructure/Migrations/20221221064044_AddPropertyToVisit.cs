using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.VisitSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyToVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstVisit",
                schema: "visit",
                table: "Visits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstVisit",
                schema: "visit",
                table: "Visits");
        }
    }
}
