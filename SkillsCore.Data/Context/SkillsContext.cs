using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Data.Mapping;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Context
{
    public class SkillsContext : DbContext
    {
        public SkillsContext(DbContextOptions<SkillsContext> options) : base(options) { }
        public SkillsContext() { }
        
        public DbSet<AcademicFormation> AcademicFormations { get; set; }
        public DbSet<AdministrationType> AdministrationTypes { get; set; }
        public DbSet<Competences> Competences { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new AcademicFormationMap());
            modelBuilder.ApplyConfiguration(new AdministrationTypeMap());
            modelBuilder.ApplyConfiguration(new CompetencesMap());
            modelBuilder.ApplyConfiguration(new EnterpriseMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new JobExperienceMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
