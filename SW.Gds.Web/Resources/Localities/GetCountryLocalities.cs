using SW.Gds.Model;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Localities
{
    public class GetCountryLocalities : IQueryHandler<string, LocalityOptions>
    {
        public GetCountryLocalities()
        {
        }

        public async Task<object> Handle(string countryCode, LocalityOptions request)
        {
            //var rs = await retrievalService.GetLocalities(countryCode, request.Locality);
            return null;
        }
    }
}
