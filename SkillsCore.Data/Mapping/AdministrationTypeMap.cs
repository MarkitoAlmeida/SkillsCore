using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class AdministrationTypeMap : IEntityTypeConfiguration<AdministrationType>
    {
        public void Configure(EntityTypeBuilder<AdministrationType> builder)
        {
            builder.ToTable("AdministrationType");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AdmType)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.HasMany<User>(x => x.Users)
                .WithOne(x => x.AdministrationType);

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
