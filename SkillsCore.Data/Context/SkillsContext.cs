using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Data.Mapping;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Context
{
    public class SkillsContext : DbContext
    {
        public SkillsContext(DbContextOptions options) : base(options) { }
        public SkillsContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<AcademicFormation> AcademicFormations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=skillscore;User ID=;Password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EnterpriseMap());
            modelBuilder.ApplyConfiguration(new AcademicFormationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
