using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillsCore.Data.Migrations
{
    public partial class ECompetenceTypePropertyColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdUserResquest",
                table: "SkillsDossier",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "guid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUserCreated",
                table: "SkillsDossier",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "guid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEnterprise",
                table: "SkillsDossier",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "guid");

            migrationBuilder.AddColumn<int>(
                name: "CompetenceType",
                table: "Competences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetenceType",
                table: "Competences");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUserResquest",
                table: "SkillsDossier",
                type: "guid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUserCreated",
                table: "SkillsDossier",
                type: "guid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEnterprise",
                table: "SkillsDossier",
                type: "guid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
