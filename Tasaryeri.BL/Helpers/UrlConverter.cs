using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.BL.Helpers
{
    public class UrlConverter
    {
        public static string ConvertUrl(string url)
        {
            return url.ToLower().Replace(" ", "-").Replace("ş", "s").Replace("ö", "o").Replace("ü", "u").Replace("ğ", "g").Replace("ç", "c").Replace("ı", "i");
        }
    }
}
