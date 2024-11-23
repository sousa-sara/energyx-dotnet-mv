using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateTipoReatorDto
    {
        [Required]
        public string DescricaoReator { get; set; } = string.Empty;
        [Required]
        public long CapacidadeEnergia { get; set; }
        [Required]
        public string Tecnologia { get; set; } = string.Empty;
        [Required]
        public string Fabricante { get; set; } = string.Empty;
    }

}
