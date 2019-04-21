using System;
using System.Collections.Generic;

namespace FCity.Currency.Service.Models.Models
{
    public class clModel
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public decimal timestamp { get; set; }

        public string source { get; set; }
        public sc quotes { get; set; }

    }
    public class sc
    {
        public float USDUSD { get; set; }
        public float USDEUR { get; set; }
        public float USDTRY { get; set; }
    }
}