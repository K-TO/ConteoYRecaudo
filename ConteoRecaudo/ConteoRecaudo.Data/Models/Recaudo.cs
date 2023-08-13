namespace ConteoRecaudo.Data.Models
{
    public class Recaudo
    {
        public string Id { get; set; }
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public int Hora { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorTabulado { get; set; }
    }
}
