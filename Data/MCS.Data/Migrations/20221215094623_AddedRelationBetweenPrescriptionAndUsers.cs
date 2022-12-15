using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCS.Data.Migrations
{
    public partial class AddedRelationBetweenPrescriptionAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorsName",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "Prescriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_DoctorId",
                table: "Prescriptions",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "DoctorsName",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
