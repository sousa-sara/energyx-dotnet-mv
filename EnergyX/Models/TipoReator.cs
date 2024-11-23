using System.ComponentModel.DataAnnotations; // Para validações
using System.ComponentModel.DataAnnotations.Schema; // Para mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_tipo_reator")]
    public class TipoReator
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipo_reator_id")]
        public long TipoReatorId { get; set; }

        // Campo obrigatório para a descrição do reator
        [Required(ErrorMessage = "A descrição do reator é obrigatória.")]
        [Column("descricao_reator")]
        [MaxLength(200)]
        public string DescricaoReator { get; set; } = string.Empty;

        // Campo obrigatório para a capacidade de energia
        [Required(ErrorMessage = "A capacidade de energia é obrigatória.")]
        [Column("capacidade_energia")]
        public long CapacidadeEnergia { get; set; }

        // Campo obrigatório para a tecnologia do reator
        [Required(ErrorMessage = "A tecnologia do reator é obrigatória.")]
        [Column("tecnologia")]
        [MaxLength(50)]
        public string Tecnologia { get; set; } = string.Empty;

        // Campo obrigatório para o fabricante do reator
        [Required(ErrorMessage = "O fabricante é obrigatório.")]
        [Column("fabricante")]
        [MaxLength(50)]
        public string Fabricante { get; set; } = string.Empty;
    }
}
