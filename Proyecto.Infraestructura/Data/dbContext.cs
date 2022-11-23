using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Proyecto.Infraestructura.Core;

namespace Proyecto.Infraestructura.Data
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__2EC8D2AC8756D07D");

                entity.ToTable("persona");

                entity.HasIndex(e => e.EmailPersona, "UQ__persona__FFE4F4FB5844AD35")
                    .IsUnique();

                entity.Property(e => e.ApellidosPersona)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPersona)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FullIdentificacion)
                    .HasMaxLength(301)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([NumIdentificacionPersona],'-',[TipoIdentificacionPersona]))", false);

                entity.Property(e => e.NombreCompletoPersona)
                    .HasMaxLength(401)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([NombresPersona],' ',[ApellidosPersona]))", false);

                entity.Property(e => e.NombresPersona)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumIdentificacionPersona)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacionPersona)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__5B65BF97159FED99");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Usuario1, "UQ__usuario__E3237CF75FCBC63D")
                    .IsUnique();

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PassUsuario)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
