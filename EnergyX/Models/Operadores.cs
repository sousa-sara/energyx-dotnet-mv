using System.ComponentModel.DataAnnotations; // Importa para usar anotações de validação
using System.ComponentModel.DataAnnotations.Schema; // Importa para usar anotações de mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_operadores")]
    public class Operadores
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("operador_id")]
        public long OperadorId { get; set; }

        // Campo obrigatório para o nome do operador
        [Required(ErrorMessage = "O nome do operador é obrigatório.")]
        [Column("nome_operador")]
        [MaxLength(50)]
        public string NomeOperador { get; set; } = string.Empty;

        // Campo obrigatório para a senha do operador
        [Required(ErrorMessage = "A senha do operador é obrigatória.")]
        [Column("senha_operador")]
        [MaxLength(50)]
        public string SenhaOperador { get; set; } = string.Empty;

        // Campo obrigatório para o cargo do operador
        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [Column("cargo")]
        [MaxLength(50)]
        public string Cargo { get; set; } = string.Empty;

        // Campo obrigatório para o LOR
        [Required(ErrorMessage = "O LOR é obrigatório.")]
        [Column("lor")]
        [MaxLength(30)]
        public string Lor { get; set; } = string.Empty;

        // Relacionamento muitos-para-um com a tabela Turnos
        [Required]
        [ForeignKey("TurnoId")]
        [Column("turno_id")]
        public long TurnoId { get; set; } // Chave estrangeira
        public Turnos Turno { get; set; } = null!; // Propriedade de navegação
    }
}
