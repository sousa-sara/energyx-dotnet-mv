namespace EnergyX.DTOs
{
    public class TipoReatorDto
    {
        public long TipoReatorId { get; set; }
        public string DescricaoReator { get; set; } = string.Empty;
        public long CapacidadeEnergia { get; set; }
        public string Tecnologia { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
    }

}
