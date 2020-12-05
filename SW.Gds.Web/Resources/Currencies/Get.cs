using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Currencies
{
    class Get : IGetHandler<string>
    {

        public Get()
        {
        }

        async public Task<object> Handle(string key, bool lookup = false)
        {
            //var currency = i18NService.Currencies.Get(key);

            //if (lookup)
            //{
            //    return currency?.Code;
            //}

            return null;
        }
    }
}
