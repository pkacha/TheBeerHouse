﻿// <auto-generated />
using System;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Persistence.Migrations
{
    [DbContext(typeof(TheBeerHouseDbContext))]
    [Migration("20240214071448_ArticleDbSet")]
    partial class ArticleDbSet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"));

                    b.Property<string>("Abstract")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<DateOnly>("AddedDate")
                        .HasColumnType("date");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("CommentsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Country")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<DateOnly?>("ExpireDate")
                        .HasColumnType("date");

                    b.Property<bool>("Listed")
                        .HasColumnType("bit");

                    b.Property<bool>("OnlyForMembers")
                        .HasColumnType("bit");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("State")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<int>("TotalRating")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("ArticleId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("API.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<DateOnly>("AddedDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("API.Models.Article", b =>
                {
                    b.HasOne("API.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("API.Models.Category", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
