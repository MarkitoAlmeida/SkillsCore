using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class SkillsDossierMap : IEntityTypeConfiguration<SkillsDossier>
    {
        public void Configure(EntityTypeBuilder<SkillsDossier> builder)
        {
            builder.ToTable("SkillsDossier");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdUserCreated)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.UserCreatedName)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnType("varchar(450)");

            builder.Property(x => x.IdUserResquest)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.UserResquestName)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnType("varchar(450)");

            builder.Property(x => x.IdEnterprise)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.EnterpriseName)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnType("varchar(300)");

            builder.Property(x => x.CreationNr)
                .IsRequired()
                .HasColumnType("int");

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
