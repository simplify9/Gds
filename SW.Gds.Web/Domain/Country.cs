using SW.PrimitiveTypes;

namespace SW.Gds.Domain
{
    class Country : BaseEntity<string>
    {
        public string IsoCode3 { get; set; }
        public short IsoNumber { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Tld { get; set; }
        public string Phone { get; set; }
        public string PostCodeFormat { get; set; }
        public string PostCodeRegex { get; set; }
        public string Languages { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
    }
}
