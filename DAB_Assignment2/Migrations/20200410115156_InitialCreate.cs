using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AUID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AUID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    AUID = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.AUID);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentAUID = table.Column<string>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(nullable: false),
                    TeacherAUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teachers",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Lecture = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Help_Where = table.Column<string>(nullable: true),
                    StudentAUID = table.Column<string>(nullable: true),
                    TeacherAUID = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => new { x.Lecture, x.Number });
                    table.ForeignKey(
                        name: "FK_Exercises_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Teachers_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teachers",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentAUID = table.Column<string>(nullable: false),
                    AssignmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.StudentAUID, x.AssignmentID });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherAUID",
                table: "Assignments",
                column: "TeacherAUID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CourseID",
                table: "Exercises",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_StudentAUID",
                table: "Exercises",
                column: "StudentAUID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TeacherAUID",
                table: "Exercises",
                column: "TeacherAUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentID",
                table: "StudentAssignment",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseID",
                table: "Teachers",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
