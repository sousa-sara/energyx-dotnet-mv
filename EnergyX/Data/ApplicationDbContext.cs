using Microsoft.EntityFrameworkCore;
using EnergyX.Models;

namespace EnergyX.Data
{
    public class ApplicationDbContext : DbContext
    {

        // DbSets para cada entidade
        public DbSet<Operadores> Operadores { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<HistoricoRelatorio> HistoricoRelatorios { get; set; }
        public DbSet<LocalizacaoReator> LocalizacoesReatores { get; set; }
        public DbSet<Reatores> Reatores { get; set; }
        public DbSet<RelatoriosTurno> RelatoriosTurnos { get; set; }
        public DbSet<TipoReator> TiposReatores { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura��o da entidade Operadores
            modelBuilder.Entity<Operadores>(entity =>
            {
                entity.ToTable("gs_el_operadores");
                entity.HasKey(e => e.OperadorId);
                entity.Property(e => e.OperadorId)
                    .HasColumnName("operador_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.NomeOperador)
                    .HasColumnName("nome_operador")
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.SenhaOperador)
                    .HasColumnName("senha_operador")
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Lor)
                    .HasColumnName("lor")
                    .IsRequired()
                    .HasMaxLength(30);

                // Configuração explícita da chave estrangeira e navegação
                entity.Property(e => e.TurnoId)
                    .HasColumnName("turno_id");

                entity.HasOne(e => e.Turno)
                    .WithMany()
                    .HasForeignKey(e => e.TurnoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gs_el_turnos_fk");
            });

            // Configura��o da entidade Turnos
            modelBuilder.Entity<Turnos>(entity =>
            {
                entity.ToTable("gs_el_turnos");
                entity.HasKey(e => e.TurnoId);
                entity.Property(e => e.TurnoId)
                    .HasColumnName("turno_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.DescricaoTurno)
                    .HasColumnName("descricao_turno")
                    .IsRequired();
            });

            // Configura��o da entidade HistoricoRelatorio
            modelBuilder.Entity<HistoricoRelatorio>(entity =>
            {
                entity.ToTable("gs_el_historico_relatorio");
                entity.HasKey(e => e.HistRelatorioId);
                entity.Property(e => e.HistRelatorioId)
                    .HasColumnName("hist_relatorio_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.DataHoraAtualizacao)
                    .HasColumnName("data_hora_atualizacao")
                    .IsRequired();
                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(150);

                // Configuração explícita da chave estrangeira e navegação
                entity.Property(e => e.RelatorioTurnoId)
                    .HasColumnName("relatorio_turno_id");

                entity.HasOne(e => e.RelatorioTurno)
                    .WithMany()
                    .HasForeignKey(e => e.RelatorioTurnoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gs_el_relatorios_turno_fk");
            });

            // Configura��o da entidade LocalizacaoReator
            modelBuilder.Entity<LocalizacaoReator>(entity =>
            {
                entity.ToTable("gs_el_localizacao_reator");
                entity.HasKey(e => e.LocReatorId);
                entity.Property(e => e.LocReatorId)
                    .HasColumnName("loc_reator_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Setor)
                    .HasColumnName("setor")
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Unidade)
                    .HasColumnName("unidade")
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(250);
            });

            // Configura��o da entidade Reatores
            modelBuilder.Entity<Reatores>(entity =>
            {
                entity.ToTable("gs_el_reatores");
                entity.HasKey(e => e.ReatorId);
                entity.Property(e => e.ReatorId)
                    .HasColumnName("reator_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.NomeReator)
                    .HasColumnName("nome_reator")
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PressaoMax)
                    .HasColumnName("pressao_max")
                    .IsRequired();
                entity.Property(e => e.TemperaturaMax)
                    .HasColumnName("temperatura_max")
                    .IsRequired();
                entity.Property(e => e.RadiacaoMax)
                    .HasColumnName("radiacao_max")
                    .IsRequired();

                // Configuração explícita da chave estrangeira e navegação
                entity.Property(e => e.TipoReatorId)
                    .HasColumnName("tipo_reator_id");

                entity.HasOne(e => e.TipoReator)
                    .WithMany()
                    .HasForeignKey(e => e.TipoReatorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gs_el_tipo_reator_fk");

                // Configuração explícita da chave estrangeira e navegação
                entity.Property(e => e.LocalizacaoReatorId)
                    .HasColumnName("loc_reator_id");

                entity.HasOne(e => e.LocalizacaoReator)
                    .WithMany()
                    .HasForeignKey(e => e.LocalizacaoReatorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gs_el_localizacao_reator_fk");
            });

            // Configura��o da entidade RelatoriosTurno
            modelBuilder.Entity<RelatoriosTurno>(entity =>
            {
                entity.ToTable("gs_el_relatorios_turno");
                entity.HasKey(e => e.RelatorioTurnoId);
                entity.Property(e => e.RelatorioTurnoId)
                    .HasColumnName("relatorio_turno_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.DataHoraRelatorio)
                    .HasColumnName("data_hora_relatorio")
                    .IsRequired();
                entity.Property(e => e.ResumoAtividades)
                    .HasColumnName("resumo_atividades")
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(300);

                // Configuração explícita da chave estrangeira e navegação
                entity.Property(e => e.OperadorId)
                    .HasColumnName("operador_id");

                entity.HasOne(e => e.Operador)
                    .WithMany()
                    .HasForeignKey(e => e.OperadorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gs_el_operadores_fk");

                // Configuração explícita da chave estrangeira e navegação
                entity.Property(e => e.ReatorId)
                    .HasColumnName("reator_id");

                entity.HasOne(e => e.Reator)
                    .WithMany()
                    .HasForeignKey(e => e.ReatorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gs_el_reatores_fk");
            });

            // Configura��o da entidade TipoReator
            modelBuilder.Entity<TipoReator>(entity =>
            {
                entity.ToTable("gs_el_tipo_reator");
                entity.HasKey(e => e.TipoReatorId);
                entity.Property(e => e.TipoReatorId)
                    .HasColumnName("tipo_reator_id")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.DescricaoReator)
                    .HasColumnName("descricao_reator")
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.CapacidadeEnergia)
                    .HasColumnName("capacidade_energia")
                    .IsRequired();
                entity.Property(e => e.Tecnologia)
                    .HasColumnName("tecnologia")
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Fabricante)
                    .HasColumnName("fabricante")
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
