using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddingEmergencyContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    EmergencyContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.EmergencyContactId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmergencyContactId",
                table: "AspNetUsers",
                column: "EmergencyContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EmergencyContacts_EmergencyContactId",
                table: "AspNetUsers",
                column: "EmergencyContactId",
                principalTable: "EmergencyContacts",
                principalColumn: "EmergencyContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EmergencyContacts_EmergencyContactId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmergencyContactId",
                table: "AspNetUsers");
        }
    }
}