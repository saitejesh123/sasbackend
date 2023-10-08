using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newprojectsas.Migrations
{
    public partial class modINIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coursename",
                table: "admissioninfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stdname",
                table: "admissioninfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coursename",
                table: "admissioninfo");

            migrationBuilder.DropColumn(
                name: "stdname",
                table: "admissioninfo");
        }
    }
}
