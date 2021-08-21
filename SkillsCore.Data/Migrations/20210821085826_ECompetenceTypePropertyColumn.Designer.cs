﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillsCore.Data.Context;

namespace SkillsCore.Data.Migrations
{
    [DbContext(typeof(SkillsContext))]
    [Migration("20210821085826_ECompetenceTypePropertyColumn")]
    partial class ECompetenceTypePropertyColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkillsCore.Domain.Models.AcademicFormation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<string>("FinalPaperTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstituitionName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("AcademicFormation");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.AdministrationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AdmType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("AdministrationType");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.Competences", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CompetenceExperienceTime")
                        .HasColumnType("int");

                    b.Property<string>("CompetenceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CompetenceType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.Property<int>("TimeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.Enterprise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<int>("FiscalNr")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StateProvince")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Enterprise");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.JobExperience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("EnterpriseName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ProjectResponsabilities")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("varchar(1500)");

                    b.Property<string>("TecnologiesUsed")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("JobExperience");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("LanguageSpeaking")
                        .HasColumnType("int");

                    b.Property<int>("LanguageUnderstanding")
                        .HasColumnType("int");

                    b.Property<int>("LanguageWriting")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.SkillsDossier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("CreationNr")
                        .HasColumnType("int");

                    b.Property<string>("EnterpriseName")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdEnterprise")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUserCreated")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUserResquest")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.Property<string>("UserCreatedName")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("UserResquestName")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.ToTable("SkillsDossier");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("DateTime");

                    b.Property<string>("CarrerTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CityOfBirth")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<int>("ExperienceTime")
                        .HasColumnType("int");

                    b.Property<int>("FiscalNr")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("IdAdministrationType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEnterprise")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StateProvince")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("IdAdministrationType");

                    b.HasIndex("IdEnterprise");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.AcademicFormation", b =>
                {
                    b.HasOne("SkillsCore.Domain.Models.User", "User")
                        .WithMany("AcademicFormations")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.Competences", b =>
                {
                    b.HasOne("SkillsCore.Domain.Models.User", "User")
                        .WithMany("Competences")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.JobExperience", b =>
                {
                    b.HasOne("SkillsCore.Domain.Models.User", "User")
                        .WithMany("JobExperiences")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.Language", b =>
                {
                    b.HasOne("SkillsCore.Domain.Models.User", "User")
                        .WithMany("Languages")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.User", b =>
                {
                    b.HasOne("SkillsCore.Domain.Models.AdministrationType", "AdministrationType")
                        .WithMany("Users")
                        .HasForeignKey("IdAdministrationType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillsCore.Domain.Models.Enterprise", "Enterprise")
                        .WithMany("Users")
                        .HasForeignKey("IdEnterprise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdministrationType");

                    b.Navigation("Enterprise");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.AdministrationType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.Enterprise", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SkillsCore.Domain.Models.User", b =>
                {
                    b.Navigation("AcademicFormations");

                    b.Navigation("Competences");

                    b.Navigation("JobExperiences");

                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}