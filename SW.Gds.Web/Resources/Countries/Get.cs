﻿using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Resources.Countries
{
    class Get : IGetHandler<string>
    {

        public Get()
        {
        }

        async public Task<object> Handle(string key, bool lookup = false)
        {
            //var country = i18NService.Countries.Get(key);

            //if (lookup)
            //{
            //    return country?.Name;
            //}

            return null;
        }
    }
}
