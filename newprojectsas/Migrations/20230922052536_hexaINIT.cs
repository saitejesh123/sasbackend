using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newprojectsas.Migrations
{
    public partial class hexaINIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admissioninfo_stdinfo_stdid",
                table: "admissioninfo");

            migrationBuilder.DropIndex(
                name: "IX_admissioninfo_stdid",
                table: "admissioninfo");

            migrationBuilder.AddColumn<int>(
                name: "stdinfostdid",
                table: "admissioninfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_admissioninfo_stdinfostdid",
                table: "admissioninfo",
                column: "stdinfostdid");

            migrationBuilder.AddForeignKey(
                name: "FK_admissioninfo_stdinfo_stdinfostdid",
                table: "admissioninfo",
                column: "stdinfostdid",
                principalTable: "stdinfo",
                principalColumn: "stdid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admissioninfo_stdinfo_stdinfostdid",
                table: "admissioninfo");

            migrationBuilder.DropIndex(
                name: "IX_admissioninfo_stdinfostdid",
                table: "admissioninfo");

            migrationBuilder.DropColumn(
                name: "stdinfostdid",
                table: "admissioninfo");

            migrationBuilder.CreateIndex(
                name: "IX_admissioninfo_stdid",
                table: "admissioninfo",
                column: "stdid");

            migrationBuilder.AddForeignKey(
                name: "FK_admissioninfo_stdinfo_stdid",
                table: "admissioninfo",
                column: "stdid",
                principalTable: "stdinfo",
                principalColumn: "stdid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
