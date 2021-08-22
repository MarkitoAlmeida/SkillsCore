using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillsCore.Data.Migrations
{
    public partial class AddSkillsDossierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillsDossier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUserCreated = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCreatedName = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false),
                    IdUserResquest = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserResquestName = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false),
                    IdEnterprise = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnterpriseName = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false),
                    CreationNr = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsDossier", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsDossier");
        }
    }
}
