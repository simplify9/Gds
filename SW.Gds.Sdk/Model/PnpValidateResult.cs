namespace SW.Gds.Model
{
    public class PnpValidateResult
    {
        public long PhoneNumber { get; set; }
        public long PhoneNumberShort { get; set; }
        public string CountryCode { get; set; }
        public PhoneType PhoneType { get; set; }
        public PnpValidateResultStatus Status { get; set; }
    }


}
