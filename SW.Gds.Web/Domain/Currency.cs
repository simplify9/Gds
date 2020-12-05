using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.Gds.Domain
{
    public class Currency : BaseEntity<string>
    {
        public string Name { get; set; }

    }
}
