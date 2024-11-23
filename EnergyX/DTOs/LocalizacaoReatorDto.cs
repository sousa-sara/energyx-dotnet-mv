namespace EnergyX.DTOs
{
    public class LocalizacaoReatorDto
    {
        public long LocReatorId { get; set; }
        public string Setor { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }

}
