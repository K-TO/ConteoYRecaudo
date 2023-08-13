using ConteoRecaudo.Data.SpModels;

namespace ConteoRecaudo.Infraestructure.Reports
{
    public class SPRecaudoYearReport
    {
        public string Estacion { get; set; }
        public ObtenerRecaudosFiltrados Values { get;set; }
    }
}
