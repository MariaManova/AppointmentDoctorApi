using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentDoctorApi.Migrations
{
    public partial class field_type_rating_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Doctor",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Doctor",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
