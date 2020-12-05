using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Gds.Util
{
    class Options
    {
        //[Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        //public bool Verbose { get; set; }

        //[Option('a', "accesskey", Required = true, HelpText = "Access key for storage.")]
        //public string AccessKeyId { get; set; }

        //[Option('s', "secret", Required = true, HelpText = "Secret access key for storage.")]
        //public string SecretAccessKey { get; set; }

        //[Option('b', "bucketname", Required = true, HelpText = "Bucket name for storage.")]
        //public string BucketName { get; set; }

        //[Option('u', "url", Required = true, HelpText = "Service Url for storage.")]
        //public string ServiceUrl { get; set; }

        [Value(0, Required = true, HelpText = "Type")]
        public string Type { get; set; }

        [Value(1, Required = true, HelpText = "Connection string")]
        public string ConnectionString { get; set; }

        [Value(2, Required = true, HelpText = "File path")]
        public string FilePath { get; set; }

    }
}
