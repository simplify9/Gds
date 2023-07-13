using Microsoft.Extensions.Configuration;
using SW.HttpExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Gds.Sdk
{
    public class GdsClientOptions : ApiClientOptionsBase
    {
        public override string ConfigurationSection => "GdsClient";
    }
}
