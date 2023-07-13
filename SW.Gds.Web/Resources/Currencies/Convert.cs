using SW.Gds.Model;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Currencies
{
    [HandlerName("convert")]
    class Convert : IQueryHandler<ConvertCurrency>
    {

        public Convert()
        {
        }

        async public Task<object> Handle(ConvertCurrency request)
        {
            //if (request.Value == 0)
            //    throw new SWException("Zero value found in request.");
            //if (request.From == null && request.To == null)
            //    throw new SWException("Missing 'from' and/or 'to' in request.");
            //else if (request.From == null)
            //    return await currenciesService.ConvertAsync(request.Value, i18NOptions.BaseCurrency, request.To);
            //else if (request.To == null)
            //    return await currenciesService.ConvertAsync(request.Value, request.From, i18NOptions.BaseCurrency);
            //else
            //    return await currenciesService.ConvertAsync(request.Value, request.From, request.To);

            return null;
        }
    }
}
