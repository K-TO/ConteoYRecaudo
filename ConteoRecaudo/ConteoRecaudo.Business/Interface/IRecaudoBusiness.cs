using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Data.SpModels;

namespace ConteoRecaudo.Business.Interface
{
    public interface IRecaudoBusiness
    {
        /// <summary>
        /// Get all collections in DB
        /// </summary>
        /// <returns></returns>
        Task<List<Recaudo>> GetAll();

        /// <summary>
        /// Get all collections per year and station
        /// </summary>
        /// <param name="year">Year for filter</param>
        /// <param name="station">Station name (this param is optional)</param>
        /// <returns></returns>
        Task<RecaudoReport> GetFromYear(int year, string? station);

        /// <summary>
        /// Obtains the collections between the selected dates
        /// </summary>
        /// <param name="beginDate">Initial date for filter</param>
        /// <param name="endDate">End date for filter</param>
        /// <returns></returns>
        Task<List<ObtenerRecaudosFiltrados>> GetFromDates(DateTime beginDate, DateTime endDate);

        /// <summary>
        /// Obtains the collections between the selected dates for station selected
        /// </summary>
        /// <param name="beginDate">Initial date for filter</param>
        /// <param name="endDate">End date for filter</param>
        /// <param name="station">Station name</param>
        /// <returns></returns>
        Task<List<ObtenerRecaudosFiltrados>> GetFromDatesAndStation(DateTime beginDate, DateTime endDate, string station);
    }
}
