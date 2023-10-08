using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newprojectsas.Migrations
{
    public partial class newINIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admissioninfo_stdinfo_studid",
                table: "admissioninfo");

            migrationBuilder.RenameColumn(
                name: "studid",
                table: "admissioninfo",
                newName: "stdid");

            migrationBuilder.RenameIndex(
                name: "IX_admissioninfo_studid",
                table: "admissioninfo",
                newName: "IX_admissioninfo_stdid");

            migrationBuilder.AddForeignKey(
                name: "FK_admissioninfo_stdinfo_stdid",
                table: "admissioninfo",
                column: "stdid",
                principalTable: "stdinfo",
                principalColumn: "stdid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admissioninfo_stdinfo_stdid",
                table: "admissioninfo");

            migrationBuilder.RenameColumn(
                name: "stdid",
                table: "admissioninfo",
                newName: "studid");

            migrationBuilder.RenameIndex(
                name: "IX_admissioninfo_stdid",
                table: "admissioninfo",
                newName: "IX_admissioninfo_studid");

            migrationBuilder.AddForeignKey(
                name: "FK_admissioninfo_stdinfo_studid",
                table: "admissioninfo",
                column: "studid",
                principalTable: "stdinfo",
                principalColumn: "stdid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
