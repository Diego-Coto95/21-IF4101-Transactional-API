using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _21_IF4101_Transactional_API.Models
{
    public partial class _21IF4101TransactionalContext : DbContext
    {
        public _21IF4101TransactionalContext()
        {
        }

        public _21IF4101TransactionalContext(DbContextOptions<_21IF4101TransactionalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=21-IF4101-Transactional;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FileNew)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("File_New");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification_Date");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Publication_Date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
