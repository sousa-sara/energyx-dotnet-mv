namespace EnergyX.DTOs
{
    public class ReatoresDto
    {
        public long ReatorId { get; set; }
        public string NomeReator { get; set; } = string.Empty;
        public long PressaoMax { get; set; }
        public long TemperaturaMax { get; set; }
        public long RadiacaoMax { get; set; }
        public long TipoReatorId { get; set; }
        public string TipoReatorDescricao { get; set; } = string.Empty; // Opcional, caso queira incluir a descrição do tipo
        public long LocalizacaoReatorId { get; set; }
        public string LocalizacaoDescricao { get; set; } = string.Empty; // Opcional, caso queira incluir a descrição da localização
    }

}
