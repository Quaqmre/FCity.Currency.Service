using System.Linq;
using System.Net;

namespace FCity.Currency.Service.Business
{
    public static class urlExtentions
    {
        public static string ToKeyValueURL(this object obj)
        {
            var keyvalues = obj.GetType().GetProperties()
                .ToList()
                .Select(p => $"{p.Name}={WebUtility.UrlEncode(p.GetValue(obj) as string)}")
                .ToArray();

            return string.Join('&', keyvalues);
        }

    }
}