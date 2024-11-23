using System;
using System.ComponentModel.DataAnnotations; // Importa para validações
using System.ComponentModel.DataAnnotations.Schema; // Importa para mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_historico_relatorio")]
    public class HistoricoRelatorio
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("hist_relatorio_id")]
        public long HistRelatorioId { get; set; }

        // Campo obrigatório para a data e hora da atualização
        [Required(ErrorMessage = "A data e hora da atualização são obrigatórias.")]
        [Column("data_hora_atualizacao")]
        public DateTime DataHoraAtualizacao { get; set; }

        // Campo opcional para observações com limite de caracteres
        [Column("observacoes")]
        [MaxLength(150)]
        public string? Observacoes { get; set; }

        // Relacionamento muitos-para-um com a tabela RelatoriosTurno
        [Required(ErrorMessage = "O relatório de turno é obrigatório.")]
        [ForeignKey("RelatorioTurnoId")]
        [Column("relatorio_turno_id")]
        public long RelatorioTurnoId { get; set; } // Chave estrangeira
        public RelatoriosTurno RelatorioTurno { get; set; } = null!; // Propriedade de navegação
    }
}
