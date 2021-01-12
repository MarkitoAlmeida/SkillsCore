using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class EnterpriseMap : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.ToTable("Enterprise");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(300)");

            builder.Property(x => x.FiscalNr)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("int");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.StateProvince)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.HasMany<User>(x => x.Users)
                .WithOne(x => x.Enterprise);

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
