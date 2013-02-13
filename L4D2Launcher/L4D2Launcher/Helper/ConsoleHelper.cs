using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using L4D2Launcher.Model;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace L4D2Launcher.Helper
{
    public class CommandHelper
    {
        public static void Execute(Parameters p)
        {
            string target = string.Format("{0}\\{1}",Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Parameters.TargetName);
            string arguments = Build(p);
            new Thread(() => _Execute(target,arguments)).Start();

        }

        private static void _Execute(string target, string arguments)
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(target,arguments);
            startInfo.Verb = "runas";
            p.StartInfo = startInfo;
            p.Start();
        }

        private static string Build(Parameters p)
        {
            List<ArgModel> args = p.ConsoleArgs();
            StringBuilder sb = new StringBuilder();

            foreach (var arg in args)
            {
                sb.AppendFormat(" {0}", arg.ToString());
            }
            return sb.ToString();
        }
    }
}
