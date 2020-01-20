using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentDoctorApi.Migrations
{
    public partial class adding_table_Appreciated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appreciated",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fk_User = table.Column<long>(nullable: false),
                    Fk_Doctor = table.Column<long>(nullable: false),
                    Assessment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appreciated", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appreciated_Doctor_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appreciated_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appreciated_Fk_Doctor",
                table: "Appreciated",
                column: "Fk_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Appreciated_Fk_User",
                table: "Appreciated",
                column: "Fk_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appreciated");
        }
    }
}
