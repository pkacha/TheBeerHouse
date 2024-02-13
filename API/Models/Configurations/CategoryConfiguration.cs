using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.AddedDate)
                    .HasColumnType("date")
                    .IsRequired(true);
            builder.Property(p => p.AddedBy)
                     .HasColumnType("nvarchar")
                     .HasMaxLength(256)
                     .IsRequired(true);
            builder.Property(p => p.Title)
                     .HasColumnType("nvarchar")
                     .HasMaxLength(256)
                     .IsRequired(true);
            builder.Property(p => p.Importance)
                    .HasColumnType("int")
                    .IsRequired(true);
            builder.Property(p => p.Description)
                    .HasColumnType("nvarchar")
                     .HasMaxLength(4000)
                     .IsRequired(false);
            builder.Property(p => p.ImageUrl)
                    .HasColumnType("nvarchar")
                     .HasMaxLength(256)
                     .IsUnicode(false)
                     .IsRequired(false);
        }
    }
}