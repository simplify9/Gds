using SW.EfCoreExtensions;
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

        public Search()
        {
        }

        async public Task<object> Handle(SearchyRequest searchyRequest, bool lookup = false, string searchPhrase = null)
        {

            //var qry = i18NService.Countries.List()
            //        .Where(c => string.IsNullOrWhiteSpace(searchPhrase) ? true : c.Name.ToLower().Contains(searchPhrase.ToLower())).AsQueryable();

            //if (lookup)
            //{
            //    IDictionary<string, string> dict = qry.OrderBy(c => c.Name)
            //        .ToDictionary(c => c.Code, c => c.Name);

            //    return dict;

            //}

            //var result = qry
            //    .Search(searchyRequest.Conditions)
            //    .ToList();

            //return Task.FromResult(new SearchyResponse<Country>
            //{
            //    Result = result,
            //    TotalCount = result.Count
            //});

            return null;

        }
    }
}
