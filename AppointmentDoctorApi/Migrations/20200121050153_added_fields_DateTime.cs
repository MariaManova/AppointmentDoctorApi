using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentDoctorApi.Migrations
{
    public partial class added_fields_DateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Doctor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "Doctor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Doctor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "Appreciated",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "Appreciated");
        }
    }
}
