using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FCity.Currency.Service.Business;
using FCity.Currency.Service.Business.Service;
using FCity.Currency.Service.Business.Service.Http.Interface;
using FCity.Currency.Service.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FCity.Currency.Service.Api
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ICurrencyService _currencyservice;
        private readonly IMinuteCurrencyService _minutecurrencyservice;
        private readonly ICurrencyHttpService _currencyhttpservice;

        public HomeController(ICurrencyService currencyservice,
                                IMinuteCurrencyService minutecurrencyservice,
                                ICurrencyHttpService currencyhttpservice
)
        {
            _currencyservice = currencyservice;
            _minutecurrencyservice = minutecurrencyservice;
            _currencyhttpservice = currencyhttpservice;

        }
        [Route("currency")]
        public async Task<IActionResult> Index()
        {

            return Ok(await _currencyservice.GetAsync());
        }
        [Route("minutecurrency")]
        public async Task<IActionResult> Get()
        {

            return Ok(await _minutecurrencyservice.GetAsync());
        }
        [Route("currencyfromapi")]
        public async Task<IActionResult> Gett()
        {

            CurrencyRequestModel asd = new CurrencyRequestModel() { currencies = "USD,EUR,TRY", format = "1" };
            var url = urlExtentions.ToKeyValueURL(asd);

            var y = await _currencyhttpservice.HttpRequest("api/live?" + url, HttpMethod.Get, null);
            var returnJson = await y.Content.ReadAsStringAsync();
            var z = JsonConvert.DeserializeObject<clModel>(returnJson);
            return Ok(z);
        }

    }
}