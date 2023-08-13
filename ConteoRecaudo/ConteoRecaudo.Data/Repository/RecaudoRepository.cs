using ConteoRecaudo.Data.Context;
using ConteoRecaudo.Data.Interface;
using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Data.SpModels;
using Microsoft.EntityFrameworkCore;

namespace ConteoRecaudo.Data.Repository
{
    public class RecaudoRepository : IRecaudoRepository
    {
        #region Members
        private readonly ConteoRecaudoContext _context;
        private readonly DbSet<Recaudo> _recaudoTable;
        #endregion

        #region Ctor
        public RecaudoRepository(ConteoRecaudoContext context)
        {
            _context = context;
            _recaudoTable = _context.Set<Recaudo>();
        }
        #endregion

        #region Methods
        public async Task<List<Recaudo>> GetAll()
        {
            return await _recaudoTable.AsQueryable().ToListAsync();
        }

        public async Task<RecaudoReport> GetFromYear(int year, string? station)
        {
            try
            {
                List<ObtenerRecaudosFiltrados> result;
                if (!string.IsNullOrEmpty(station))
                {
                    result = _context.ObtenerRecaudosFiltrados.FromSqlRaw($"EXEC spObtenerRecaudosPorAnio @Estacion = '{station}', @Anio = {year}").ToList();
                }
                else
                {
                    result = _context.ObtenerRecaudosFiltrados.FromSqlRaw($"EXEC spObtenerRecaudosPorAnio @Estacion = '', @Anio = {year}").ToList();
                }

                RecaudoReport recaudoReport = new RecaudoReport()
                {
                    TotalCantidad = result.Sum(x => x.Cantidad),
                    TotalValor = result.Sum(x => x.Valor)
                };

                recaudoReport.sPRecaudoYearReport = result.GroupBy(x => x.Estacion).Select(x => new SPRecaudoYearReport()
                {
                    Estacion = x.Key,
                    Values = x.Where(s => s.Estacion.Equals(x.Key)).Select(x => x).ToList(),
                    subTotalCantidad = x.Sum(x => x.Cantidad),
                    subTotalValor = x.Sum(x => x.Valor)
                }).ToList();

                return recaudoReport;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ObtenerRecaudosFiltrados>> GetFromDates(DateTime beginDate, DateTime endDate)
        {
            try
            {
                return _context.ObtenerRecaudosFiltrados.FromSqlRaw($"EXEC spObtenerRecaudosFecha @FechaInicial = '{beginDate.ToString("yyyy/MM/dd")}', @FechaFinal = '{endDate.ToString("yyyy/MM/dd")}'").ToList(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ObtenerRecaudosFiltrados>> GetFromDatesAndStation(DateTime beginDate, DateTime endDate, string station)
        {
            try
            {
                return _context.ObtenerRecaudosFiltrados.FromSqlRaw($"EXEC spObtenerRecaudosEstacionFecha @Estacion = '{station}', @FechaInicial = '{beginDate.ToString("yyyy/MM/dd")}', @FechaFinal = '{endDate.ToString("yyyy/MM/dd")}'").ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
