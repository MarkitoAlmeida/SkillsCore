using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class JobExperienceMap : IEntityTypeConfiguration<JobExperience>
    {
        public void Configure(EntityTypeBuilder<JobExperience> builder)
        {
            builder.ToTable("JobExperience");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EnterpriseName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.BeginDate)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.FinalDate)
                .HasColumnType("DateTime");

            builder.Property(x => x.JobTitle)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(x => x.ProjectDescription)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.ProjectResponsabilities)
                .IsRequired()
                .HasMaxLength(1500)
                .HasColumnType("varchar(1500)");

            builder.Property(x => x.TecnologiesUsed)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnType("varchar(1000)");

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.JobExperiences)
                .HasForeignKey(x => x.IdUser);

            builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(x => x.Excluded)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(x => x.CreationDate)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.LastUpdate)
                .IsRequired()
                .HasColumnType("DateTime");
        }
    }
}
