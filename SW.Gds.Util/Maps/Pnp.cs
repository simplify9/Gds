using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using SW.Gds.Model;

namespace SW.Gds.Util.Maps
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

        public class Map : ClassMap<Pnp>
        {
            public Map()
            {
                //AutoMap();
                Map(m => m.CNS).Name("CNS");//.TypeConverter<ConvertStringToLong>();
                Map(m => m.Country).Name("ISO-3166-alpha_2");
                //Map(m => m.NationalSignificantNumber).Name("national_significant_number");
                Map(m => m.Type).Name("type_id").TypeConverter<PhoneTypeConverter<PhoneType>>();
                Map(m => m.AreaCodeLength).Name("area_code_length");
                Map(m => m.MinLength).Name("min_subscr_nr_length");
                Map(m => m.MaxLength).Name("max_subscr_nr_length");

                //Map(m => m.InternationalCode).Name("country_code");

            }

            private class PhoneTypeConverter<T> : EnumConverter where T : struct
            {
                public PhoneTypeConverter() : base(typeof(T)) { }

                public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
                {
                    if (text == "MOB")
                    {
                        return PhoneType.Mobile;
                    }
                    else if (text == "FIX")
                    {
                        return PhoneType.Landline;
                    }

                    return PhoneType.Other;
                }

            }
        }


    }


}
