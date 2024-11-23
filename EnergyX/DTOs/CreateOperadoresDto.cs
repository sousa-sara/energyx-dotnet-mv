using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateOperadoresDto
    {
        [Required]
        public string NomeOperador { get; set; } = string.Empty;

        public string SenhaOperador { get; set; } = string.Empty;
        [Required]
        public string Cargo { get; set; } = string.Empty;
        [Required]
        public string Lor { get; set; } = string.Empty;
        [Required]
        public long TurnoId { get; set; }
    }

}
