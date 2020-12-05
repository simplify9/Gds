using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using SW.Gds.Util.Model;
using SW.PrimitiveTypes;

namespace SW.Gds.Util
{

    internal class PnpMap : ClassMap<Pnp>
    {
        public PnpMap()
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
