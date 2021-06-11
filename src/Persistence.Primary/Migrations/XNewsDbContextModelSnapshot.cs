﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Primary.DataAccess;

namespace Persistence.Primary.Migrations
{
    [DbContext(typeof(XNewsDbContext))]
    partial class XNewsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryPost", b =>
                {
                    b.Property<Guid>("CategoriesCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostsPostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesCategoryId", "PostsPostId");

                    b.HasIndex("PostsPostId");

                    b.ToTable("CategoryPost");
                });

            modelBuilder.Entity("Domain.Primary.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("CategoryId");

                    b.HasIndex(new[] { "Title" }, "UQ_Category")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Domain.Primary.Entities.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<Guid?>("ParentCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CommentId");

                    b.HasIndex(new[] { "ParentCommentId" }, "IX_Comment_ParentCommentId");

                    b.HasIndex(new[] { "PostId" }, "IX_Comment_PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.Primary.Entities.CommentRate", b =>
                {
                    b.Property<Guid>("CommentRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CommentRateId");

                    b.HasIndex("CommentId", "UserId")
                        .IsUnique();

                    b.HasIndex(new[] { "CommentId" }, "IX_CommentRate_CommentId");

                    b.ToTable("CommentRate");
                });

            modelBuilder.Entity("Domain.Primary.Entities.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(72)
                        .HasColumnType("nvarchar(72)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PostId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Domain.Primary.Entities.PostRate", b =>
                {
                    b.Property<Guid>("PostRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PostRateId");

                    b.HasIndex("PostId", "UserId")
                        .IsUnique();

                    b.HasIndex(new[] { "PostId" }, "IX_PostRate_PostId");

                    b.ToTable("PostRate");
                });

            modelBuilder.Entity("CategoryPost", b =>
                {
                    b.HasOne("Domain.Primary.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Primary.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Primary.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Primary.Entities.Comment", "ParentComment")
                        .WithMany("InverseParentComment")
                        .HasForeignKey("ParentCommentId")
                        .HasConstraintName("FK_Comment_ParentComment");

                    b.HasOne("Domain.Primary.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentComment");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Primary.Entities.CommentRate", b =>
                {
                    b.HasOne("Domain.Primary.Entities.Comment", "Comment")
                        .WithMany("CommentRates")
                        .HasForeignKey("CommentId")
                        .HasConstraintName("FK_CommentRate_CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Domain.Primary.Entities.PostRate", b =>
                {
                    b.HasOne("Domain.Primary.Entities.Post", "Post")
                        .WithMany("PostRates")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostRate_PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Primary.Entities.Comment", b =>
                {
                    b.Navigation("CommentRates");

                    b.Navigation("InverseParentComment");
                });

            modelBuilder.Entity("Domain.Primary.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostRates");
                });
#pragma warning restore 612, 618
        }
    }
}
