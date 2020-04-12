using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment2.Migrations
{
    public partial class AddedShadowTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Assignments_AssignmentID",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Students_StudentAUID",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseID",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentAUID",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentAssignment",
                newName: "StudentAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssignment_AssignmentID",
                table: "StudentAssignments",
                newName: "IX_StudentAssignments_AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentAUID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                columns: new[] { "StudentAUID", "AssignmentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_Assignments_AssignmentID",
                table: "StudentAssignments",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_Students_StudentAUID",
                table: "StudentAssignments",
                column: "StudentAUID",
                principalTable: "Students",
                principalColumn: "AUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseID",
                table: "StudentCourses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentAUID",
                table: "StudentCourses",
                column: "StudentAUID",
                principalTable: "Students",
                principalColumn: "AUID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_Assignments_AssignmentID",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_Students_StudentAUID",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseID",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentAUID",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "StudentAssignments",
                newName: "StudentAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssignments_AssignmentID",
                table: "StudentAssignment",
                newName: "IX_StudentAssignment_AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "StudentAUID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment",
                columns: new[] { "StudentAUID", "AssignmentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Assignments_AssignmentID",
                table: "StudentAssignment",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Students_StudentAUID",
                table: "StudentAssignment",
                column: "StudentAUID",
                principalTable: "Students",
                principalColumn: "AUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseID",
                table: "StudentCourse",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentAUID",
                table: "StudentCourse",
                column: "StudentAUID",
                principalTable: "Students",
                principalColumn: "AUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
