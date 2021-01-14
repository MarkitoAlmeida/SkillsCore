using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillsCore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    FiscalNr = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    StateProvince = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    FiscalNr = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    StateProvince = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOfBirth = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ExperienceTime = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false),
                    IdAdministrationType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEnterprise = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AdministrationType_IdAdministrationType",
                        column: x => x.IdAdministrationType,
                        principalTable: "AdministrationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Enterprise_IdEnterprise",
                        column: x => x.IdEnterprise,
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicFormation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituitionName = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    ConclusionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CourseTitle = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    FinalPaperTitle = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicFormation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicFormation_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetenceName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CompetenceExperienceTime = table.Column<int>(type: "int", nullable: false),
                    TimeType = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competences_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnterpriseName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BeginDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ProjectDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    ProjectResponsabilities = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false),
                    TecnologiesUsed = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobExperience_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LanguageUnderstanding = table.Column<int>(type: "int", nullable: false),
                    LanguageWriting = table.Column<int>(type: "int", nullable: false),
                    LanguageSpeaking = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Language_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicFormation_IdUser",
                table: "AcademicFormation",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_IdUser",
                table: "Competences",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_JobExperience_IdUser",
                table: "JobExperience",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Language_IdUser",
                table: "Language",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdAdministrationType",
                table: "User",
                column: "IdAdministrationType");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdEnterprise",
                table: "User",
                column: "IdEnterprise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicFormation");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "JobExperience");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AdministrationType");

            migrationBuilder.DropTable(
                name: "Enterprise");
        }
    }
}
