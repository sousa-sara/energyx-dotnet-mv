using System.ComponentModel.DataAnnotations; // Para validações
using System.ComponentModel.DataAnnotations.Schema; // Para mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_reatores")]
    public class Reatores
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("reator_id")]
        public long ReatorId { get; set; }

        // Campo obrigatório para o nome do reator
        [Required(ErrorMessage = "O nome do reator é obrigatório.")]
        [Column("nome_reator")]
        [MaxLength(50)]
        public string NomeReator { get; set; } = string.Empty;

        // Campo obrigatório para a pressão máxima
        [Required(ErrorMessage = "A pressão máxima é obrigatória.")]
        [Column("pressao_max")]
        public long PressaoMax { get; set; }

        // Campo obrigatório para a temperatura máxima
        [Required(ErrorMessage = "A temperatura máxima é obrigatória.")]
        [Column("temperatura_max")]
        public long TemperaturaMax { get; set; }

        // Campo obrigatório para a radiação máxima
        [Required(ErrorMessage = "A radiação máxima é obrigatória.")]
        [Column("radiacao_max")]
        public long RadiacaoMax { get; set; }

        // Relacionamento muitos-para-um com a tabela TipoReator
        [Required(ErrorMessage = "O tipo de reator é obrigatório.")]
        [ForeignKey("TipoReatorId")]
        [Column("tipo_reator_id")]
        public long TipoReatorId { get; set; } // Chave estrangeira
        public TipoReator TipoReator { get; set; } = null!; // Propriedade de navegação

        // Relacionamento muitos-para-um com a tabela LocalizacaoReator
        [Required(ErrorMessage = "A localização do reator é obrigatória.")]
        [ForeignKey("LocalizacaoReatorId")]
        [Column("loc_reator_id")]
        public long LocalizacaoReatorId { get; set; } // Chave estrangeira
        public LocalizacaoReator LocalizacaoReator { get; set; } = null!; // Propriedade de navegação
    }
}
