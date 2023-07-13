using CsvHelper;
using Npgsql;
using NpgsqlTypes;
using SW.Gds.Util.Maps;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Util.Services
{
    class ImportCountries : IImport
    {
        public string Name => "country";

        async public Task Import(string path, NpgsqlConnection dbConnection)
        {
            using var fileStream = new FileStream(@"c:\temp\countryInfo.txt", FileMode.Open);
            using var reader = new StreamReader(fileStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Configuration.Delimiter = "\t";
            csv.Configuration.RegisterClassMap<Country.Map>();
            csv.Configuration.Encoding = Encoding.UTF8;
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.AllowComments = true;
            csv.Configuration.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;

            csv.Configuration.BadDataFound = c => Console.WriteLine(c.RawRow);

            var records = csv.GetRecordsAsync<Country>();
            using var writer = dbConnection.
                BeginBinaryImport(@"COPY gds.country (id, iso_code3, iso_number, 
                                    name, capital, tld, phone, 
                                    post_code_format, post_code_regex, 
                                    languages, currency_code, currency_name) 
                                    FROM STDIN (FORMAT BINARY)");

            await foreach (var r in records)
            {

                await writer.StartRowAsync();
                await writer.WriteAsync(r.Code);
                await writer.WriteAsync(r.IsoCode);
                await writer.WriteAsync(r.IsoNumber, NpgsqlDbType.Smallint);
                await writer.WriteAsync(r.Name);
                await writer.WriteAsync(r.Capital);
                await writer.WriteAsync(r.Tld);
                await writer.WriteAsync(r.Phone);
                await writer.WriteAsync(r.PostCodeFormat);
                await writer.WriteAsync(r.PostCodeRegex);
                await writer.WriteAsync(r.Languages);
                await writer.WriteAsync(r.CurrencyCode);
                await writer.WriteAsync(r.CurrencyName);

            }

            await writer.CompleteAsync();  

        }
    }
}
