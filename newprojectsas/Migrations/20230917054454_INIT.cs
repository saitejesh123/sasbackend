using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newprojectsas.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    courseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coursename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coursefees = table.Column<int>(type: "int", nullable: false),
                    coursedescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courselink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.courseid);
                });

            migrationBuilder.CreateTable(
                name: "stdinfo",
                columns: table => new
                {
                    stdid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stdname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    confirm_password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    usertype = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stdinfo", x => x.stdid);
                });

            migrationBuilder.CreateTable(
                name: "admissioninfo",
                columns: table => new
                {
                    addid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studid = table.Column<int>(type: "int", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissioninfo", x => x.addid);
                    table.ForeignKey(
                        name: "FK_admissioninfo_course_courseid",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissioninfo_stdinfo_studid",
                        column: x => x.studid,
                        principalTable: "stdinfo",
                        principalColumn: "stdid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admissioninfo_courseid",
                table: "admissioninfo",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_admissioninfo_studid",
                table: "admissioninfo",
                column: "studid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admissioninfo");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "stdinfo");
        }
    }
}
