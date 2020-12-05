using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Gds.Util.Model
{

    internal class Pnp
    {
        public long CNS { get; set; }



        public string Country { get; set; }
        //public Country Country { get; set; }
        public PhoneType Type { get; set; }
        //public string Location { get; set; }
        public short? AreaCodeLength { get; set; }
        public short? MinLength { get; set; }
        //public short InternationalCode { get; set; }
        public short? MaxLength { get; set; }
        //public string Registrar { get; set; }
        //public string CreatedBy { get; set; }



    }


}
