using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Gds.Util
{
    internal interface IImport
    {
        Task Import(string path, NpgsqlConnection dbConnection);
    }
}
