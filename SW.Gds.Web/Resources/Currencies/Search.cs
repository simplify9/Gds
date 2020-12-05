using SW.PrimitiveTypes;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Currencies
{
    class Search : ISearchyHandler
    {

        public Search()
        {
        }

        async public Task<object> Handle(SearchyRequest searchyRequest, bool lookup = false, string searchPhrase = null)
        {

            //var qry = i18NService.Currencies.List()
            //        .Where(c => string.IsNullOrWhiteSpace(searchPhrase) ? true : c.Code.ToLower().Contains(searchPhrase.ToLower())).AsQueryable(); 


            //if (lookup)
            //{
            //    IDictionary<string, string> dict = qry.OrderBy(c => c.Code)
            //        .ToDictionary(c => c.Code, c => c.Code);

            //    return dict;
            //}

            //var result = qry
            //    .Search(searchyRequest.Conditions)
            //    .ToList();

            //return Task.FromResult(new SearchyResponse<Currency>
            //{
            //    Result = result,
            //    TotalCount = result.Count
            //});

            return null;
        }
    }
}
