using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCS.Data.Migrations
{
    public partial class AddedImageUrlToDepartmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Departments");
        }
    }
}
