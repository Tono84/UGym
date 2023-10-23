using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddingUserFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    UserFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CirguriesType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantCirguries = table.Column<int>(type: "int", nullable: false),
                    DetailCirguries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeMeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantMeds = table.Column<int>(type: "int", nullable: true),
                    AlergyMeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeartDis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChestPain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSitting = table.Column<int>(type: "int", nullable: true),
                    SleepCycle = table.Column<int>(type: "int", nullable: true),
                    LastMonthStress = table.Column<int>(type: "int", nullable: true),
                    TrainMotivation = table.Column<int>(type: "int", nullable: true),
                    FatDifLoss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LmonthEnergy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepsDay = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthEx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceMotivation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Focus = table.Column<int>(type: "int", nullable: true),
                    Nutrition = table.Column<int>(type: "int", nullable: true),
                    StressNutrition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.UserFileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserFileId",
                table: "AspNetUsers",
                column: "UserFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserFiles_UserFileId",
                table: "AspNetUsers",
                column: "UserFileId",
                principalTable: "UserFiles",
                principalColumn: "UserFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserFiles_UserFileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserFileId",
                table: "AspNetUsers");
        }
    }
}