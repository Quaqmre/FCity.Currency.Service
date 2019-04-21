using System.Net.Http;
using System.Threading.Tasks;
using FCity.Currency.Service.Business.Service.Http.Interface;

namespace FCity.Currency.Service.Business.Service.Http
{
    public class MainHttpService : IMainHttpService
    {
        private readonly HttpClient _client;

        public MainHttpService(
           HttpClient client)
        {
            _client = client;

        }
        public async Task<HttpResponseMessage> HttpRequest(string Url, HttpMethod httpMethod, string contentJson)
        {
            using (var request = new HttpRequestMessage(httpMethod, Url))
            {
                var response = await _client.SendAsync(request);
                return response;
            }

        }
    }
}