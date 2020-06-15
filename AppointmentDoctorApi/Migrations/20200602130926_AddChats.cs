using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentDoctorApi.Migrations
{
    public partial class AddChats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorChat",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fk_Patient = table.Column<long>(nullable: false),
                    Fk_Doctor = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorChat_Doctor_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorChat_Patient_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fk_Author = table.Column<long>(nullable: false),
                    Fk_DoctorChat = table.Column<long>(nullable: false),
                    Text = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User_Fk_Author",
                        column: x => x.Fk_Author,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessage_DoctorChat_Fk_DoctorChat",
                        column: x => x.Fk_DoctorChat,
                        principalTable: "DoctorChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_Fk_Author",
                table: "ChatMessage",
                column: "Fk_Author");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_Fk_DoctorChat",
                table: "ChatMessage",
                column: "Fk_DoctorChat");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorChat_Fk_Doctor",
                table: "DoctorChat",
                column: "Fk_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorChat_Fk_Patient",
                table: "DoctorChat",
                column: "Fk_Patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "DoctorChat");
        }
    }
}
