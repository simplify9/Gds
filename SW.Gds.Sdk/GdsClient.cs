using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SW.Gds.Model;
using SW.HttpExtensions;
using SW.PrimitiveTypes;

namespace SW.Gds.Sdk
{
    public class GdsClient : ApiClientBase<GdsClientOptions>, IBasicApiClient
    {
        public GdsClient(HttpClient httpClient, RequestContext requestContext, GdsClientOptions mtmClientOptions) : base(httpClient, requestContext, mtmClientOptions)
        {
        }

        public Task<ApiResult<string>> LookupValue(string searchUrl)
        {
            return Builder.Jwt().Path(searchUrl).AsApiResult<string>().GetAsync();
        }

        public Task<ApiResult<SearchyResponse<TModel>>> Search<TModel>(string searchUrl)
        {
            return Builder.Jwt().Path(searchUrl).AsApiResult<SearchyResponse<TModel>>().GetAsync();
        }

        public Task<ApiResult<PnpValidateResult>> ValidatePhone<PnpValidateResult>(string url, PnpValidate pnpValidate)
        {
            return Builder.Jwt().
            Path($"{url}?phone={pnpValidate.Phone}&country={pnpValidate.Country.EmptyIfNull()}").
            AsApiResult<PnpValidateResult>().GetAsync();
        }

        public Task<ApiResult<IDictionary<string, string>>> Search(string searchUrl)
        {
            return Builder.Jwt().Path(searchUrl).AsApiResult<IDictionary<string, string>>().GetAsync();
        }

    }
}
