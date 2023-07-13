using SW.Gds.Model;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.Gds.Domain
{
    class PhoneNumberingPlan : BaseEntity<long>
    {
        public string Country { get; set; }
        //public Country Country { get; set; }
        public PhoneType Type { get; set; }
        //public string Location { get; set; }
        public byte AreaCodeLength { get; set; }
        public byte MinLength { get; set; }
        //public short InternationalCode { get; set; }
        public byte MaxLength { get; set; }    }
}
