using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denolk.XchangeWrapper.Helper
{
    internal class ConfigHelper
    {
        public static string XChangeHost
        {
            get
            {
                return ConfigurationManager.AppSettings["ExchangeService"];
            }
        }
    }
}
