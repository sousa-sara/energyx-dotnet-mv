using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class OperadoresDto
    {
        public long OperadorId { get; set; }
        public string NomeOperador { get; set; } = string.Empty;
        public string SenhaOperador { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Lor { get; set; } = string.Empty;
        public long TurnoId { get; set; }
    }

}
