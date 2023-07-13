//using System;
//using System.Collections.Generic;

//namespace SW.Gds
//{
//    public class CountriesService
//    {

//        private readonly IDictionary<string, Country> cntryd;

//        public CountriesService()
//        {
//            var assembly = typeof(I18nServiceService).Assembly;
//            var cntryds = assembly.GetManifestResourceStream("SW.Gds.Api.Data.cntryd.bin");
//            var manifestress = assembly.GetManifestResourceNames();
//            cntryd = new Dictionary<string, Country>(cntryds.AsDictionary<Country>(), StringComparer.OrdinalIgnoreCase);
            
//        }

//        public IEnumerable<Country> List()
//        {
//            return cntryd.Values; 
//        }

//        public Country Get(string CountryCode)
//        {
//            cntryd.TryGetValue(CountryCode, out var c);
//            return c;
//        }

//        public bool TryGet(string CountryCode, out Country country)
//        {
//            if (cntryd.TryGetValue(CountryCode, out country)) return true;
//            return false;
//        }

//    }
//}
