using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentDoctorApi.Migrations
{
    public partial class added_fields_for_rating_calculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumRated",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSumRating",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumRated",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "TotalSumRating",
                table: "Doctor");
        }
    }
}
