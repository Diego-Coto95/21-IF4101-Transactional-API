using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _21_IF4101_Transactional_API.Models.Entities
{
    public partial class _21IF4101TransactionalAPIContext : DbContext
    {
        public _21IF4101TransactionalAPIContext()
        {
        }

        public _21IF4101TransactionalAPIContext(DbContextOptions<_21IF4101TransactionalAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=21-IF4101-Transactional-API;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FileNews)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModificationDate)
                    .IsRequired()
                    .HasColumnName("Modification_Date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublicationDate)
                    .IsRequired()
                    .HasColumnName("Publication_Date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NewsComment>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNewsNavigation)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.IdNews)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsComment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
