using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class AcademicFormationMap : IEntityTypeConfiguration<AcademicFormation>
    {
        public void Configure(EntityTypeBuilder<AcademicFormation> builder)
        {
            builder.ToTable("AcademicFormation");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.InstituitionName)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("varchar(300)");

            builder.Property(x => x.ConclusionDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.CourseTitle)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("varchar(300)");

            builder.Property(x => x.FinalPaperTitle)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("varchar(300)");

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
