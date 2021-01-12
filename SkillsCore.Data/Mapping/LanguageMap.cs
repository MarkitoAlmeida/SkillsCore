using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Mapping
{
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LanguageName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.LanguageUnderstanding)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.LanguageWriting)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.LanguageSpeaking)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Languages)
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
