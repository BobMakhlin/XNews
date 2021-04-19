﻿using Domain.Primary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Primary.Configurations
{
    public class PostRateConfig : IEntityTypeConfiguration<PostRate>
    {
        public void Configure(EntityTypeBuilder<PostRate> builder)
        {
            builder
                .ToTable("PostRate");

            builder
                .Property(e => e.PostRateId)
                .HasDefaultValueSql("NEWID()");
                
            builder
                .HasIndex(e => e.PostId, "IX_PostRate_PostId");
                
            builder
                .HasOne(d => d.Post)
                .WithMany(p => p.PostRates)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostRate_PostId");
        }
    }
}