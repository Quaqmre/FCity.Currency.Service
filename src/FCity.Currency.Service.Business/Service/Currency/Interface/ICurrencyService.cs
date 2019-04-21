using System.Collections.Generic;
using System.Threading.Tasks;
using FCity.Currency.Service.Models;
using FCity.Currency.Service.Models.Models;

namespace FCity.Currency.Service.Business.Service
{
    public interface ICurrencyService
    {
        Task<List<CurrencyModel>> GetAsync();
        RestSharp.IRestResponse GetCurrency();
    }
}