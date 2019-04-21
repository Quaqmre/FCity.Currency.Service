using System.Net.Http;
using System.Threading.Tasks;

namespace FCity.Currency.Service.Business.Service.Http.Interface
{
    public interface IMainHttpService
    {
        Task<HttpResponseMessage> HttpRequest(string Url, HttpMethod httpMethod, string contentJson);
    }
}