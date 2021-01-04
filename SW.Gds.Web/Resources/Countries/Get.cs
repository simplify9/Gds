using Microsoft.EntityFrameworkCore;
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
    class Get : IGetHandler<string>
    {
        private readonly GdsDbContext dbContext;

        public Get(GdsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async public Task<object> Handle(string key, bool lookup = false)
        {
            IQueryable<Country> qry;

            if (short.TryParse(key, out var keyShort))
                qry = dbContext.Set<Country>().AsNoTracking().Where(p => p.IsoNumber == keyShort);

            else if (key.Length == 3)
                qry = dbContext.Set<Country>().AsNoTracking().Where(p => EF.Functions.ILike(p.IsoCode3, key));

            else if (key.Length == 2)
                qry = dbContext.Set<Country>().AsNoTracking().Where(p => EF.Functions.ILike(p.Id, key));

            else 
                throw new SWNotFoundException(key); 

            if (lookup)
                return await qry.Select(p => p.Name).SingleOrDefaultAsync();

            else
                return await qry.Select(i => new CountryGet
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

                }).SingleOrDefaultAsync();


        }
    }
}
