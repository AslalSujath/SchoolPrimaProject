using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPrimaProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarksValue = table.Column<double>(name: "Marks_Value", type: "float", nullable: false),
                    StudentId = table.Column<int>(name: "Student_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(name: "School_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(name: "School_Name", type: "nvarchar(max)", nullable: false),
                    SchoolAddress = table.Column<string>(name: "School_Address", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Studens",
                columns: table => new
                {
                    Studentid = table.Column<int>(name: "Student_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(name: "Student_Name", type: "nvarchar(max)", nullable: false),
                    StudentDob = table.Column<DateTime>(name: "Student_Dob", type: "datetime2", nullable: false),
                    StudentGrade = table.Column<int>(name: "Student_Grade", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studens", x => x.Studentid);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subjectid = table.Column<int>(name: "Subject_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(name: "Subject_Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subjectid);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacherid = table.Column<int>(name: "Teacher_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(name: "Teacher_Name", type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<int>(name: "School_Id", type: "int", nullable: false),
                    Subjectid = table.Column<int>(name: "Subject_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacherid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Studens");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
