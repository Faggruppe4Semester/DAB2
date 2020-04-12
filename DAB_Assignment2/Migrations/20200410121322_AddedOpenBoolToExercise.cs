using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment2.Migrations
{
    public partial class AddedOpenBoolToExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Open",
                table: "Exercises",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Open",
                table: "Exercises");
        }
    }
}
