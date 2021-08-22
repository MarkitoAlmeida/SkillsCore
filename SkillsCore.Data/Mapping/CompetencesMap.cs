using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class CompetencesMap : IEntityTypeConfiguration<Competences>
    {
        public void Configure(EntityTypeBuilder<Competences> builder)
        {
            builder.ToTable("Competences");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompetenceName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.CompetenceExperienceTime)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.TimeType)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.CompetenceType)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Competences)
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
