using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using T_31JUL.Model;

namespace T_31JUL.Data;

public partial class T31julContext : DbContext
{
    public T31julContext()
    {
    }

    public T31julContext(DbContextOptions<T31julContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencia { get; set; }

    public virtual DbSet<Inscripciones> Inscripciones { get; set; }

    public virtual DbSet<Participantes> Participantes { get; set; }

    public virtual DbSet<Talleres> Talleres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DKS9NUA\\MSSQLSERVER01; Database=T-31JUL; Trusted_Connection=True; MultipleActiveResultSets=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__Asistenc__3956DEE6DDD498E4");

            entity.Property(e => e.IdAsistencia).ValueGeneratedNever();
            entity.Property(e => e.FechaAsistencia).HasColumnType("datetime");

            entity.HasOne(d => d.IdInscripcionNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdInscripcion)
                .HasConstraintName("FK__Asistenci__IdIns__3F466844");
        });

        modelBuilder.Entity<Inscripciones>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PK__Inscripc__A122F2BFD21095BC");

            entity.Property(e => e.IdInscripcion).ValueGeneratedNever();
            entity.Property(e => e.FechaInscripcion).HasColumnType("datetime");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("FK__Inscripci__IdPar__3B75D760");

            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdTaller)
                .HasConstraintName("FK__Inscripci__IdTal__3C69FB99");
        });

        modelBuilder.Entity<Participantes>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK__Particip__56139242BBD4BD24");

            entity.Property(e => e.IdParticipante).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Talleres>(entity =>
        {
            entity.HasKey(e => e.IdTaller).HasName("PK__Talleres__AC44FFD6B4DA0368");

            entity.Property(e => e.IdTaller).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
