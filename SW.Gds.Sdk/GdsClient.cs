using Microsoft.Extensions.Configuration;
using SW.HttpExtensions;
using SW.PrimitiveTypes;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SW.Gds.Sdk
{
    public class GdsClient : ApiClientBase<GdsClientOptions>
    {
        public GdsClient(HttpClient httpClient, RequestContext requestContext, GdsClientOptions mtmClientOptions) : base(httpClient, requestContext, mtmClientOptions)
        {
        }


    }
}
