using System.Collections.Generic;
using System.Threading.Tasks;
using FCity.Currency.Service.Models.Models;

namespace FCity.Currency.Service.Business.Service
{
    public class MinuteCurrencyService : IMinuteCurrencyService
    {
        private readonly IRepository<MinuteCurrencyModel> _minutecurrencyRepository;
        public MinuteCurrencyService(IRepository<MinuteCurrencyModel> minutecurrencyRepository)
        {
            _minutecurrencyRepository = minutecurrencyRepository;

        }
        public async Task<List<MinuteCurrencyModel>> GetAsync()
        {
            var x = await _minutecurrencyRepository.GetListAsync();

            return x;
        }

    }
}