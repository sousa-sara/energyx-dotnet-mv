using System;
using System.ComponentModel.DataAnnotations; // Para validações
using System.ComponentModel.DataAnnotations.Schema; // Para mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_relatorios_turno")]
    public class RelatoriosTurno
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("relatorio_turno_id")]
        public long RelatorioTurnoId { get; set; }

        // Campo obrigatório para a data e hora do relatório
        [Required(ErrorMessage = "A data e hora do relatório são obrigatórias.")]
        [Column("data_hora_relatorio")]
        public DateTime DataHoraRelatorio { get; set; }

        // Campo obrigatório para o resumo das atividades
        [Required(ErrorMessage = "O resumo das atividades é obrigatório.")]
        [Column("resumo_atividades")]
        [MaxLength(200)]
        public string ResumoAtividades { get; set; } = string.Empty;

        // Campo opcional para observações
        [Column("observacoes")]
        [MaxLength(300)]
        public string Observacoes { get; set; } = string.Empty;

        // Relacionamento muitos-para-um com Operadores
        [Required(ErrorMessage = "O operador é obrigatório.")]
        [ForeignKey("OperadorId")]
        [Column("operador_id")]
        public long OperadorId { get; set; } // Chave estrangeira
        public Operadores Operador { get; set; } = null!; // Propriedade de navegação

        // Relacionamento muitos-para-um com TipoReator
        [Required(ErrorMessage = "O reator é obrigatório.")]
        [ForeignKey("ReatorId")]
        [Column("reator_id")]
        public long ReatorId { get; set; } // Chave estrangeira
        public Reatores Reator { get; set; } = null!; // Propriedade de navegação
    }
}
