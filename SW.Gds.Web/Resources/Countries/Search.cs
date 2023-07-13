using Microsoft.EntityFrameworkCore;
using SW.EfCoreExtensions;
using SW.Gds.Domain;
using SW.Gds.Model;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Countries
{
    class Search : ISearchyHandler
    {
        private readonly GdsDbContext dbContext;

        public Search(GdsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async public Task<object> Handle(SearchyRequest searchyRequest, bool lookup = false, string searchPhrase = null)
        {

            var qry = dbContext.
                Set<Country>().
                AsNoTracking().
                Where(c => string.IsNullOrWhiteSpace(searchyRequest.SearchPhrase) || EF.Functions.ILike(c.Name, $"%{searchyRequest.SearchPhrase}%"));

            if (searchyRequest.Format == 0)
            {

                return await qry.
                    Select(i => new CountrySearch
                    {
                        Code = i.Id,
                        Capital = i.Capital,
                        CurrencyCode = i.CurrencyCode,
                        CurrencyName = i.CurrencyName,
                        IsoCode3 = i.IsoCode3,
                        IsoNumber = i.IsoNumber,
                        Languages = i.Languages,
                        Name = i.Name,
                        Phone = i.Phone,
                        PostCodeFormat = i.PostCodeFormat,
                        PostCodeRegex = i.PostCodeRegex,
                        Tld = i.Tld

                    }).
                    ToSearchyResponseAsync(searchyRequest);

            }
            else if (searchyRequest.Format == 1)
            {

                return await qry.
                    OrderBy(c => c.Name).
                    ToDictionaryAsync(searchyRequest, c => c.Id, c => c.Name);
            }

            return null;
        }
    }
}
