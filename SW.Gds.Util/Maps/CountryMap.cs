using CsvHelper.Configuration;
using SW.Gds.Util.Model;

namespace SW.Gds.Util
{

    internal class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {

            Map(m => m.Code).Index(0);
            Map(m => m.IsoCode).Index(1);
            Map(m => m.IsoNumber).Index(2);
            Map(m => m.Name).Index(4);

            Map(m => m.Capital).Index(5);
            //Map(m => m.Continent).Index(8);
            Map(m => m.Tld).Index(9);
            Map(m => m.CurrencyCode).Index(10);
            Map(m => m.CurrencyName).Index(11);

            Map(m => m.Phone).Index(12);
            Map(m => m.PostCodeFormat).Index(13);
            Map(m => m.PostCodeRegex).Index(14);
            Map(m => m.Languages).Index(15);

        }
    }

}
