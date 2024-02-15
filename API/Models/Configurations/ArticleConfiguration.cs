using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(p => p.AddedDate).HasColumnType("date").IsRequired();
            builder.Property(p => p.AddedBy).HasColumnType("nvarchar").HasMaxLength(256).IsRequired(true);
            builder.Property(p => p.Title).HasColumnType("nvarchar").HasMaxLength(256).IsRequired(true);
            builder.Property(p => p.Abstract).HasColumnType("nvarchar").HasMaxLength(4000).IsRequired(false);
            builder.Property(p => p.Body).HasColumnType("ntext").IsRequired();
            builder.Property(p => p.AddedBy).HasColumnType("nvarchar").HasMaxLength(256).IsRequired(true);
            builder.Property(p => p.Country).HasColumnType("nvarchar").HasMaxLength(256).IsRequired(false);
            builder.Property(p => p.State).HasColumnType("nvarchar").HasMaxLength(256).IsRequired(false);
            builder.Property(p => p.City).HasColumnType("nvarchar").HasMaxLength(256).IsRequired(false);
            builder.Property(p => p.ReleaseDate).HasColumnType("date").IsRequired(false);
            builder.Property(p => p.ExpireDate).HasColumnType("date").IsRequired(false);
            builder.Property(p => p.Approved).HasColumnType("bit");
            builder.Property(p => p.Listed).HasColumnType("bit");
            builder.Property(p => p.CommentsEnabled).HasColumnType("bit");
            builder.Property(p => p.OnlyForMembers).HasColumnType("bit");
            builder.Property(p => p.ViewCount).HasColumnType("int");
            builder.Property(p => p.Votes).HasColumnType("int");
            builder.Property(p => p.TotalRating).HasColumnType("int");
            builder.Ignore(p => p.Location);
            builder.Ignore(p => p.AverageRating);
            builder.Ignore(p => p.Published);
        }
    }
}