namespace ConteoRecaudo.Data.SpModels
{
    public class RecaudoReport
    {
        public decimal TotalValor { get; set; }
        public int TotalCantidad { get; set; }
        public List<SPRecaudoYearReport> sPRecaudoYearReport { get; set; }
    }

    public class SPRecaudoYearReport
    {
        public string Estacion { get; set; }
        public List<ObtenerRecaudosFiltrados> Values { get;set; }
        public decimal subTotalValor { get; set; }
        public int subTotalCantidad { get; set; }
    }
}
