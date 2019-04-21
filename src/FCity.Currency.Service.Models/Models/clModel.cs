using System;
using System.Collections.Generic;

namespace FCity.Currency.Service.Models.Models
{
    public class clModel
    {
        public bool Success { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public decimal TimeStamp { get; set; }

        public string Source { get; set; }
        public sc Quotes { get; set; }

    }
    public class sc
    {
        public float USDUSD { get; set; }
        public float USDEUR { get; set; }
        public float USDTRY { get; set; }
    }
}