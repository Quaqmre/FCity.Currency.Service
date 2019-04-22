namespace FCity.Currency.Service.Models.Models
{
    public class CurrencyRequestModel
    {
        public CurrencyRequestModel()
        {
            access_key = "03c6064100c7960dff435324bcdee1eb";
            source = "USD";
        }

        public string access_key { get; }
        public string currencies { get; set; }
        public string source { get; }

        public string format { get; set; }


    }
}