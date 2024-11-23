using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class UpdateRelatoriosTurnoDto
    {
        public long RelatorioTurnoId { get; set; }
        public DateTime DataHoraRelatorio { get; set; }
        public string ResumoAtividades { get; set; }
        public string Observacoes { get; set; }
        public long OperadorId { get; set; }
        public long ReatorId { get; set; }
    }

}
