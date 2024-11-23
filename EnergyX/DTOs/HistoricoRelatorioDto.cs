namespace EnergyX.DTOs
{
    public class HistoricoRelatorioDto
    {
        public long HistRelatorioId { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
        public string? Observacoes { get; set; }
        public long RelatorioTurnoId { get; set; }
    }

}
