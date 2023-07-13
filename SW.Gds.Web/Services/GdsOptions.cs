using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Gds
{
    class GdsOptions
    {
        public const string ConfigurationSection = "Gds";
        public string CurrencyRatesUrl { get; set; }
        public int CurrencyRatesCacheDuration { get; set; } = 60;
        public string BaseCurrency { get; set; } = "usd";
    }
}
