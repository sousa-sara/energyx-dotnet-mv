using System.ComponentModel.DataAnnotations;

namespace EnergyX.DTOs
{
    public class CreateReatoresDto
    {
        [Required]
        public string NomeReator { get; set; } = string.Empty;
        [Required]
        public long PressaoMax { get; set; }
        [Required]
        public long TemperaturaMax { get; set; }
        [Required]
        public long RadiacaoMax { get; set; }
        [Required]
        public long TipoReatorId { get; set; }
        [Required]
        public string TipoReatorDescricao { get; set; } = string.Empty;
        [Required]
        public long LocalizacaoReatorId { get; set; }
        [Required]
        public string LocalizacaoDescricao { get; set; } = string.Empty;
    }

}
