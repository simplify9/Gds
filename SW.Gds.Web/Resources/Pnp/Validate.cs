using Microsoft.EntityFrameworkCore;
using SW.Gds.Domain;
using SW.Gds.Model;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Pnp
{

    public class Validate : IQueryHandler<PnpValidate>
    {
        private readonly GdsDbContext dbContext;

        public Validate(GdsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async public Task<object> Handle(PnpValidate request)
        {
            var ret = new PnpValidateResult()
            {
                Status = PnpValidateResultStatus.BadPhone
            };

            //var phone = request.Phone.Trim().NullIfEmpty();

            if (string.IsNullOrWhiteSpace(request.Phone)) return ret;

            string phone = string.Empty;

            foreach (var c in request.Phone)
                if (char.IsDigit(c)) phone = string.Concat(phone, c);

            phone = long.Parse(phone).ToString();

            Country country = null;

            if (!string.IsNullOrWhiteSpace(request.Country))
            {
                country = await dbContext.
                    Set<Country>().
                    FirstOrDefaultAsync(i => EF.Functions.ILike(i.Id, request.Country));

                if (country != null)
                {
                    if (!phone.StartsWith(country.Phone))
                    {
                        phone = string.Concat(country.Phone, phone);
                    }
                }
            }

            var idList = new List<long>();
            for (int i = phone.Length; i > 3; i--)
            {
                idList.Add(long.Parse(phone.Substring(0, i)));
            }

            var pnp = await dbContext.
                Set<PhoneNumberingPlan>().
                Where(i => idList.Contains(i.Id)).
                OrderByDescending(i => i.Id).
                FirstOrDefaultAsync();

            if (pnp == null) return ret;

            if (country == null)
                country = await dbContext.Set<Country>().FindAsync(pnp.Country);

            var localnumlen = phone.Length - country.Phone.Length - pnp.AreaCodeLength;

            if (localnumlen < pnp.MinLength)
            {
                ret.Status = PnpValidateResultStatus.TooShort;
                return ret;
            }

            if (localnumlen > (int)pnp.MaxLength)
            {
                ret.Status = PnpValidateResultStatus.TooLong;
                return ret;
            }


            switch (pnp.Type)
            {
                case PhoneType.Mobile:
                    ret.PhoneType = PhoneType.Mobile;
                    break;
                case PhoneType.Landline:
                    ret.PhoneType = PhoneType.Landline;
                    break;
                default:
                    ret.PhoneType = PhoneType.Other;
                    break;

            }

            ret.CountryCode = pnp.Country;
            ret.PhoneNumber = long.Parse(phone);
            ret.PhoneNumberShort = long.Parse(phone.Substring(country.Phone.Length));
            ret.Status = PnpValidateResultStatus.Ok;

            return ret;
        }
    }
}
