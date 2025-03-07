using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevateWorkforceSolutionsJP.Migrations
{
    /// <inheritdoc />
    public partial class remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo",
                table: "JoblistViewModel");

            migrationBuilder.DropColumn(
                name: "logo",
                table: "Joblists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "JoblistViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "Joblists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
