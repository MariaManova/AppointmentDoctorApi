using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentDoctorApi.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfWork",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamePlace = table.Column<string>(type: "Nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameSpeciality = table.Column<string>(type: "Nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Enum_Gender = table.Column<int>(nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Fk_Photo = table.Column<long>(nullable: false),
                    Enum_Role = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Images_Fk_Photo",
                        column: x => x.Fk_Photo,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fk_Speciality = table.Column<long>(nullable: false),
                    Fk_PlaceOfWork = table.Column<long>(nullable: false),
                    Enum_Category = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Fk_User = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_PlaceOfWork_Fk_PlaceOfWork",
                        column: x => x.Fk_PlaceOfWork,
                        principalTable: "PlaceOfWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Speciality_Fk_Speciality",
                        column: x => x.Fk_Speciality,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "Nvarchar(200)", nullable: true),
                    Fk_User = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fk_Doctor = table.Column<long>(nullable: false),
                    TimeReceipt = table.Column<DateTime>(nullable: false),
                    IsBusy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedule_Doctor_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fk_Doctor = table.Column<long>(nullable: false),
                    Fk_Patient = table.Column<long>(nullable: false),
                    DateTimeReceipt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Fk_Doctor",
                table: "Appointment",
                column: "Fk_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Fk_Patient",
                table: "Appointment",
                column: "Fk_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Fk_PlaceOfWork",
                table: "Doctor",
                column: "Fk_PlaceOfWork");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Fk_Speciality",
                table: "Doctor",
                column: "Fk_Speciality");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Fk_User",
                table: "Doctor",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Fk_User",
                table: "Patient",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_User_Fk_Photo",
                table: "User",
                column: "Fk_Photo");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedule_Fk_Doctor",
                table: "WorkSchedule",
                column: "Fk_Doctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "WorkSchedule");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "PlaceOfWork");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
