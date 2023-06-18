using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.Core.Abstract;

namespace Tasaryeri.Core.Helpers
{
    public class UrlConverter : IUrlConverter
    {
        public string ConvertUrl(string url)
        {
            return url.ToLower().Replace(" ", "-").Replace("ş", "s").Replace("ö", "o").Replace("ü", "u").Replace("ğ", "g").Replace("ç", "c").Replace("ı", "i");
        }
    }
}
