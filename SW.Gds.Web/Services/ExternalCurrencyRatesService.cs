﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SW.Gds.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds
{
    class ExternalCurrencyRatesService
    {
        private readonly HttpClient httpClient;
        private readonly GdsOptions i18NOptions;

        public ExternalCurrencyRatesService(HttpClient httpClient, GdsOptions i18NOptions)
        {
            this.httpClient = httpClient;
            this.i18NOptions = i18NOptions;
        }

        async public Task<CurrencyRates> GetRates()
        {
            var httpResponseMessage = await httpClient.GetAsync($"{i18NOptions.CurrencyRatesUrl}&base={i18NOptions.BaseCurrency}");
            httpResponseMessage.EnsureSuccessStatusCode();
            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            JToken jToken = JObject.Parse(responseBody);
            var doc = jToken.SelectToken("rates")?.ToString();

            if (doc == null)
                throw new Exception("Failed to get currency rates");

            return new CurrencyRates()
            {
                Rates = new Dictionary<string, decimal>(JsonConvert.DeserializeObject<IDictionary<string, decimal>>(doc), StringComparer.OrdinalIgnoreCase)
            };
        }
    }
}
