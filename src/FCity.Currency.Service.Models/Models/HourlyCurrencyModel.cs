using System;

namespace FCity.Currency.Service.Models.Models
{
    public class HourlyCurrencyModel
    {
        public int CurrencyId { get; set; }
        public int CurrencyType { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public string CurrencyName { get; set; }

        public decimal CurrencyRate { get; set; }
        public string CurrencyExchangeRateSource { get; set; }
        // public bool AddedDayly { get; set; } //v0.0.2 de eklenecek alandır
        public int HourlyCurrencyId { get; set; }
        public int CurrentHour { get; set; }
    }
}