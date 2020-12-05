using CsvHelper;
using Npgsql;
using NpgsqlTypes;
using SW.Gds.Util.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Util.Services
{
    class ImportPnp : IImport
    {
        async public Task Import(string path, NpgsqlConnection dbConnection)
        {
            using var fileStream = new FileStream(@"c:\temp\E164_PSTN_csv_v2002.csv", FileMode.Open);
            using var reader = new StreamReader(fileStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.Delimiter = ";";
            csv.Configuration.RegisterClassMap<PnpMap>();

            var records = csv.GetRecordsAsync<Pnp>();

            using var writer = dbConnection.
                BeginBinaryImport(@"COPY gds.phone_numbering_plan 
                                    (id, country, type, area_code_length, 
                                    min_length, max_length) 
                                    FROM STDIN (FORMAT BINARY)");

            var duplicateDetection = new HashSet<long>();

            await foreach (var r in records)
            {

                if (!duplicateDetection.Contains(r.CNS) &&  r.Type != PhoneType.Other && r.AreaCodeLength.HasValue && r.MinLength.HasValue && r.MaxLength.HasValue)
                {
                    //    //cntryd.TryAdd(r.Country, new CountryValue() { DialingPrefix = (short)r.CNS });
                    //}
                    duplicateDetection.Add(r.CNS);

                    await writer.StartRowAsync();
                    await writer.WriteAsync(r.CNS);
                    await writer.WriteAsync(r.Country);
                    await writer.WriteAsync((byte)r.Type, NpgsqlDbType.Smallint);
                    await writer.WriteAsync(r.AreaCodeLength.Value, NpgsqlDbType.Smallint);
                    await writer.WriteAsync(r.MinLength.Value, NpgsqlDbType.Smallint);
                    await writer.WriteAsync(r.MaxLength.Value, NpgsqlDbType.Smallint);
                }

                //Console.WriteLine($"{r.CNS},{r.Country}");
            }

            await writer.CompleteAsync();  

            //
            //pnpd.TryAdd("97154", new PnpValue() { AreaCodeLength = 0, Country = "AE", MaxLength = 9, MinLength = 9, Type = "MOB" });
            //pnpd.TryAdd("97158", new PnpValue() { AreaCodeLength = 0, Country = "AE", MaxLength = 9, MinLength = 9, Type = "MOB" });
            //pnpd.TryAdd("961719", new PnpValue() { AreaCodeLength = 0, Country = "LB", MaxLength = 8, MinLength = 8, Type = "MOB" });

        }
    }
}
