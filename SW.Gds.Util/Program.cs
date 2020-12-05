using CommandLine;
using Npgsql;
using SW.Gds.Util.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Gds.Util
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
              .WithParsedAsync(RunOptions).Result
              .WithNotParsed(HandleParseError);
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            //Console.ReadKey();
        }

        async static Task RunOptions(Options opts)
        {
            try
            {
                Environment.ExitCode = 1;


                switch (opts.Type.ToLower())
                {
                    case "country":
                        await using (var connection = new NpgsqlConnection(opts.ConnectionString))
                        {
                            await connection.OpenAsync();
                            var import = new ImportCountries();
                            await import.Import(opts.FilePath, connection);
                        };
                        break;

                    case "pnp":
                        await using (var connection = new NpgsqlConnection(opts.ConnectionString))
                        {
                            await connection.OpenAsync();
                            var import = new ImportPnp();
                            await import.Import(opts.FilePath, connection);
                        };
                        break;

                    default:
                        throw new NotImplementedException();
                }
                //code

                Environment.ExitCode = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
