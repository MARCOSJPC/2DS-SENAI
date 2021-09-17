using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_hroades_webAPI.Domains;

#nullable disable

namespace senai_hroades_webAPI.Contexts
{
    public partial class HroadesContext : DbContext
    {
        public HroadesContext()
        {
        }

        public HroadesContext(DbContextOptions<HroadesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClasseDomain> Classes { get; set; }
        public virtual DbSet<HabilidadeDomain> Habilidades { get; set; }
        public virtual DbSet<HabilidadeClasseDomain> HabilidadeClasses { get; set; }
        public virtual DbSet<PersonagemDomain> Personagems { get; set; }
        public virtual DbSet<TipoHabilidadeDomain> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuarioDomain> TipoUsuarios { get; set; }
        public virtual DbSet<UsuarioDomain> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-TVA27R8T\\SQLEXPRESS; initial catalog=senai_hroades_tarde; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ClasseDomain>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classes__60FFF801C6842369");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.TipoClasse)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipoClasse");
            });

            modelBuilder.Entity<HabilidadeDomain>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F752860C29754");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Habilidad__idTip__4222D4EF");
            });

            modelBuilder.Entity<HabilidadeClasseDomain>(entity =>
            {
                entity.HasKey(e => e.IdHabClasse)
                    .HasName("PK__Habilida__B4DA2B0FC7554136");

                entity.ToTable("HabilidadeClasse");

                entity.Property(e => e.IdHabClasse).HasColumnName("idHabClasse");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.HabilidadeClasses)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Habilidad__idCla__45F365D3");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadeClasses)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Habilidad__idHab__44FF419A");
            });

            modelBuilder.Entity<PersonagemDomain>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72ED8738B8B");

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("date")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.MaxMana)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maxMana");

                entity.Property(e => e.MaxVida)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maxVida");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__3F466844");
            });

            modelBuilder.Entity<TipoHabilidadeDomain>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TipoHabi__BDD0DFE116097017");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.TipoHabilidade1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TipoHabilidade");
            });

            modelBuilder.Entity<TipoUsuarioDomain>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF8E8DFC23");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<UsuarioDomain>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6C0E1D541");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__idTipo__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
