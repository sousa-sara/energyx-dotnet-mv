using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateTurnosDto
    {
        [Required]
        public string DescricaoTurno { get; set; } = string.Empty;
    }

}
