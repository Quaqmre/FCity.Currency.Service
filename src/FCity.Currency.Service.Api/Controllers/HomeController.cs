using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCity.Currency.Service.Business.Service;
using FCity.Currency.Service.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FCity.Currency.Service.Api
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ICurrencyService _currencyservice;
        private readonly IMinuteCurrencyService _minutecurrencyservice;
        public HomeController(ICurrencyService currencyservice,
                                IMinuteCurrencyService minutecurrencyservice)
        {
            _currencyservice = currencyservice;
            _minutecurrencyservice = minutecurrencyservice;
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
        public IActionResult Gett()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            var x = _currencyservice.GetCurrency();
            return Ok();
        }

    }
}