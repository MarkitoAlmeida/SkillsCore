using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillsCore.Data.Migrations
{
    public partial class AddCarrerTitleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrerTitle",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrerTitle",
                table: "User");
        }
    }
}
