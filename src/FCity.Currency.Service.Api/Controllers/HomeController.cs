using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FCity.Currency.Service.Api
{
    [Route("account")]
    public class HomeController : Controller
    {
        private readonly CurrencyContex _currencycontext;
        public HomeController(CurrencyContex context)
        {
            _currencycontext = context;
        }
        public async Task<IActionResult> Index()
        {

            return Ok(await _currencycontext.Currency.ToListAsync());
        }

    }
}