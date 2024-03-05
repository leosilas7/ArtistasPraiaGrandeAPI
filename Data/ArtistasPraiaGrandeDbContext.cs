using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArtistasPraiaGrandeAPI.Models;

#nullable disable

namespace ArtistasPraiaGrandeAPI.Data
{
    public partial class ArtistasPraiaGrandeDbContext : DbContext
    {
        public ArtistasPraiaGrandeDbContext()
        {
        }

        public ArtistasPraiaGrandeDbContext(DbContextOptions<ArtistasPraiaGrandeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artista> Artistas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SEPLAN-0332\\SQLEXPRESS01;Initial Catalog=artistas;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.HasKey(e => e.IdArtista)
                    .HasName("PK__artistas__98CBB7BBECC62E4C");

                entity.ToTable("artistas");

                entity.Property(e => e.IdArtista).HasColumnName("id_artista");

                entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deferido)
                    .HasColumnName("deferido")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.NomeArtistico)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeArtistico");

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeCompleto");

                entity.Property(e => e.NomeSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeSocial");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
