using System;
using System.ComponentModel.DataAnnotations; // Importa para usar validações
using System.ComponentModel.DataAnnotations.Schema; // Importa para mapeamento de banco de dados

namespace EnergyX.Models
{
    // Define a tabela correspondente no banco de dados
    [Table("gs_el_turnos")]
    public class Turnos
    {
        // Chave primária gerada automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("turno_id")]
        public long TurnoId { get; set; }

        // Campo obrigatório para o cargo do operador
        [Required(ErrorMessage = "A descrição turno é obrigatório.")]
        [Column("descricao_turno")]
        [MaxLength(50)]
        public string DescricaoTurno { get; set; } = string.Empty;
    }
}
