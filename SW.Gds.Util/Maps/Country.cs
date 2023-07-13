using CsvHelper.Configuration;

namespace SW.Gds.Util.Maps
{
    internal class Country
    {

        public string Tld { get; set; }
        public string Phone { get; set; }
        public string PostCodeFormat { get; set; }
        public string PostCodeRegex { get; set; }
        public string Languages { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public short IsoNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string Capital { get; set; }

        public class Map : ClassMap<Country>
        {
            public Map()
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
}
