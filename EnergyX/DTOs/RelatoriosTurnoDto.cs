using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class RelatoriosTurnoDto
    {
        public long RelatorioTurnoId { get; set; }
        public DateTime DataHoraRelatorio { get; set; } = DateTime.UtcNow.AddHours(-3);
        public string ResumoAtividades { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;
        public long OperadorId { get; set; }
        public long ReatorId { get; set; }
    }

}
