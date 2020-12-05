using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Gds
{
    public class CurrencyRates
    {
        public DateTime LastModified { get; set; }
        public IDictionary<string, decimal> Rates { get; set; }

    }

}
