using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineNews.Models
{
    public partial class OnlineNewsPRContext : DbContext
    {
        public OnlineNewsPRContext()
        {
        }

        public OnlineNewsPRContext(DbContextOptions<OnlineNewsPRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<New> News { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =LAPTOP-LNDPLEOA\\SQLEXPRESS; Database=OnlineNewsPR;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Categoryid)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryid");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<New>(entity =>
            {
                entity.HasKey(e => e.Newsid)
                    .HasName("PK__New__954FA1CB445BB97F");

                entity.ToTable("New");

                entity.Property(e => e.Newsid).ValueGeneratedNever();

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Datetime)
                    .HasColumnType("date")
                    .HasColumnName("#datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_New_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
