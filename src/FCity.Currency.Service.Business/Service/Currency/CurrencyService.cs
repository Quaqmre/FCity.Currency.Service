using System.Collections.Generic;
using System.Threading.Tasks;
using FCity.Currency.Service.Models;
using FCity.Currency.Service.Models.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FCity.Currency.Service.Business.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepository<CurrencyModel> _currencyRepository;
        public CurrencyService(IRepository<CurrencyModel> currencyRepository)
        {
            _currencyRepository = currencyRepository;

        }
        public async Task<List<CurrencyModel>> GetAsync()
        {
            var x = await _currencyRepository.GetListAsync();

            return x;
        }

        public clModel GetCurrency()
        {
            var client = new RestClient("http://apilayer.net/api/live?access_key=03c6064100c7960dff435324bcdee1eb&currencies=USD,EUR,TRY&format=1");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var json = JsonConvert.DeserializeObject<clModel>(response.Content);
            return json;
        }

    }
}