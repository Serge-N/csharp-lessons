using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Crud.Models
{
    public partial class LearnContext : DbContext
    {
        public LearnContext()
        {
        }

        public LearnContext(DbContextOptions<LearnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
