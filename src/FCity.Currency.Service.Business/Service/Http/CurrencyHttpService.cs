using System.Net.Http;
using System.Threading.Tasks;
using FCity.Currency.Service.Business.Service.Http.Interface;

namespace FCity.Currency.Service.Business.Service.Http
{
    public class CurrencyHttpService : MainHttpService, ICurrencyHttpService
    {
        public CurrencyHttpService(HttpClient client) : base(client)
        {

        }
    }
}