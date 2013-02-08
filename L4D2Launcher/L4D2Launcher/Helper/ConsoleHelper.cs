﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using L4D2Launcher.Model;
using System.Threading;
using System.Diagnostics;

namespace L4D2Launcher.Helper
{
    public class CommandHelper
    {
        public static void Execute(Parameters p)
        {
            string command = Build(p);
            //Thread thread = new Thread(() => _Execute(command));
        }

        private static void _Execute(string command) {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(command);
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
                sb.AppendFormat("{0} ", arg.ToString());
            }
            return sb.ToString();
        }
    }
}
