using System.ComponentModel.DataAnnotations; // Para validações
using System.ComponentModel.DataAnnotations.Schema; // Para mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_localizacao_reator")]
    public class LocalizacaoReator
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("loc_reator_id")]
        public long LocReatorId { get; set; }

        // Campo obrigatório para o setor
        [Required(ErrorMessage = "O setor é obrigatório.")]
        [Column("setor")]
        [MaxLength(50)]
        public string Setor { get; set; } = string.Empty;

        // Campo obrigatório para a unidade
        [Required(ErrorMessage = "A unidade é obrigatória.")]
        [Column("unidade")]
        [MaxLength(20)]
        public string Unidade { get; set; } = string.Empty;

        // Campo opcional para a descrição
        [Column("descricao")]
        [MaxLength(250)]
        public string? Descricao { get; set; }
    }
}
