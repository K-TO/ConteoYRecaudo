namespace ConteoRecaudo.Data.SpModels
{
    public class ObtenerRecaudosFiltrados
    {
        public string Estacion { get; set; }
        public int Anio { get; set; }
        public string Mes { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor { get; set; }
    }
}
