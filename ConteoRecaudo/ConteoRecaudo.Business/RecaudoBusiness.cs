using ConteoRecaudo.Business.Interface;
using ConteoRecaudo.Data.Interface;
using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Data.SpModels;

namespace ConteoRecaudo.Business
{
    public class RecaudoBusiness : IRecaudoBusiness
    {
        #region Members
        private readonly IRecaudoRepository _repository;
        #endregion

        #region Ctor
        public RecaudoBusiness(IRecaudoRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<List<Recaudo>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<RecaudoReport> GetFromYear(int year, string? station)
        {
            return await _repository.GetFromYear(year, station);
        }

        public async Task<List<ObtenerRecaudosFiltrados>> GetFromDates(DateTime beginDate, DateTime endDate)
        {
            return await _repository.GetFromDates(beginDate, endDate);
        }

        public async Task<List<ObtenerRecaudosFiltrados>> GetFromDatesAndStation(DateTime beginDate, DateTime endDate, string station)
        {
            return await _repository.GetFromDatesAndStation(beginDate, endDate, station);
        }
        #endregion
    }
}
