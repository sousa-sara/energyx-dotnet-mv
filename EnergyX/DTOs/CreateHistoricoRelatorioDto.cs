using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateHistoricoRelatorioDto
    {
        [Required]
        public DateTime DataHoraAtualizacao { get; set; } = DateTime.Now;
        [Required]
        public string? Observacoes { get; set; } = string.Empty;
        [Required]
        public long RelatorioTurnoId { get; set; }
    }

}
