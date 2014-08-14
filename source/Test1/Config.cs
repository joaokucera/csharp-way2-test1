using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public static class Config
    {
        public static string Way2WordUri = ConfigurationManager.AppSettings[Way2WordKey];

        private const string Way2WordKey = "Way2Words";
    }
}
