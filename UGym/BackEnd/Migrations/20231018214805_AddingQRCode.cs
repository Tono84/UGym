using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddingQRCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmergencyContactId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnowGym",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motivation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ocupation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QrcodeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFileId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Qrcodes",
                columns: table => new
                {
                    QrcodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkQr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qrcodes", x => x.QrcodeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0043b54d-a383-4c2a-b4e8-3a7de145978f", "5", "Therapist", "Terapeuta" },
                    { "0a252d9d-f40f-4a89-80f9-fb59cdaede24", "2", "User", "Socio" },
                    { "1b60d8b6-9b0d-4d46-a55c-5a30a5efa770", "3", "Nutritionist", "Nutricionista" },
                    { "5f070c79-1064-4e7c-9a86-d10f8a63bae6", "1", "Administrator", "Administrador" },
                    { "db755e9b-5073-4bd1-919e-35c313d3118b", "4", "Receptionist", "Recepcionista" },
                    { "de2863a2-8485-4d85-9ab6-c9e2cade49ad", "6", "Coach", "Entrenador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_QrcodeId",
                table: "AspNetUsers",
                column: "QrcodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Qrcodes_QrcodeId",
                table: "AspNetUsers",
                column: "QrcodeId",
                principalTable: "Qrcodes",
                principalColumn: "QrcodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Qrcodes_QrcodeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Qrcodes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_QrcodeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0043b54d-a383-4c2a-b4e8-3a7de145978f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a252d9d-f40f-4a89-80f9-fb59cdaede24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b60d8b6-9b0d-4d46-a55c-5a30a5efa770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f070c79-1064-4e7c-9a86-d10f8a63bae6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db755e9b-5073-4bd1-919e-35c313d3118b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de2863a2-8485-4d85-9ab6-c9e2cade49ad");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmergencyContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KnowGym",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Motivation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ocupation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "QrcodeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserFileId",
                table: "AspNetUsers");
        }
    }
}
