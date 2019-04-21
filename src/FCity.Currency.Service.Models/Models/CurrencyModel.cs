using System;

namespace FCity.Currency.Service.Models.Models
{
    public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        public int CurrencyType { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public string CurrencyName { get; set; }

        public decimal CurrencyRate { get; set; }
        public string CurrencyExchangeRateSource { get; set; }

    }
}