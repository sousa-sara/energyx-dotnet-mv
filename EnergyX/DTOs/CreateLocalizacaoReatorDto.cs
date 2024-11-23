using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateLocalizacaoReatorDto
    {
        [Required]
        public string Setor { get; set; } = string.Empty;
        [Required]
        public string Unidade { get; set; } = string.Empty;
        [Required]
        public string Descricao { get; set; } = string.Empty;
    }

}
