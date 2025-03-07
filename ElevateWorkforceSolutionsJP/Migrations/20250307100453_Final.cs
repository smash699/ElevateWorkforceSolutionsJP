using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevateWorkforceSolutionsJP.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "JobApplicationViewModel",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "JobApplicationViewModel",
                newName: "OrganizationName");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "JobApplications",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "JobApplications",
                newName: "OrganizationName");

            migrationBuilder.AddColumn<string>(
                name: "AcademicQualification",
                table: "JobApplicationViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "JobApplicationViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AcademicQualification",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicQualification",
                table: "JobApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "JobApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "AcademicQualification",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "JobApplicationViewModel",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "OrganizationName",
                table: "JobApplicationViewModel",
                newName: "Resume");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "JobApplications",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "OrganizationName",
                table: "JobApplications",
                newName: "Resume");
        }
    }
}
