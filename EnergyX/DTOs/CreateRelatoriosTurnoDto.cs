using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateRelatoriosTurnoDto
    {
        public DateTime DataHoraRelatorio { get; set; } = DateTime.UtcNow.AddHours(-3);
        [Required]
        public string ResumoAtividades { get; set; } = string.Empty;
        [Required]
        public string Observacoes { get; set; } = string.Empty;
        [Required]
        public long OperadorId { get; set; }
        [Required]
        public long ReatorId { get; set; }
    }

}
