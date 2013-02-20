using denolk.netcf.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace denolk.netcf.Helper
{
    public class NICHelper
    {

        public static Dictionary<string, NetworkConfigModel> ReadNICSettings()
        {
            List<NetworkInterface> nilist = NetworkInterface.GetAllNetworkInterfaces().ToList();
            Dictionary<string, NetworkConfigModel> settings = new Dictionary<string, NetworkConfigModel>();

            foreach (var ni in nilist)
            {
                if ((ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                    || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                    || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet3Megabit
                    || ni.NetworkInterfaceType == NetworkInterfaceType.FastEthernetFx
                    || ni.NetworkInterfaceType == NetworkInterfaceType.FastEthernetT
                    || ni.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet)
                    && !ni.Description.ToLowerInvariant().Contains("vmware"))
                {
                    settings[ni.Name] = new NetworkConfigModel(ni);
                }
            }

            return settings;
        }

        private const string NETSH = "netsh";
        private const string NETSH_IP = "interface ip set address \"{0}\" static {1} {2} {3} 1";    //name-ip-mask-gateway
        private const string NETSH_DNS = "interface ip set dns \"{0}\" static {1}";                 //name-dns
        private const string NETSH_DNS_ADD = "interface ip add dns \"{0}\" static {1} index={2}";   //name-dns-index
        private const string NETSH_IP_DHCP = "interface ip set address \"{0}\" dhcp";   //name
        private const string NETSH_DNS_DHCP = "interface ip set dns \"{0}\" dhcp";      //name

        public static bool SaveNICSettings(NetworkConfigModel model)
        {
            try
            {
                List<string> commands = BuildCommand(model);

                foreach (var cmd in commands)
                {
                    Process p = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo(NETSH, cmd);
                    startInfo.Verb = "runas";
                    startInfo.CreateNoWindow = true;
                    p.StartInfo = startInfo;
                    p.Start();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        private static List<string> BuildCommand(NetworkConfigModel model)
        {
            List<string> commands = new List<string>();
            if (model.UseDHCP)
            {
                commands.Add(string.Format(NETSH_IP_DHCP, model.NetworkName));
            }
            else
            {
                commands.Add(string.Format(NETSH_IP, model.NetworkName, model.IpAddress, model.Subnet, model.Gateway));
            }

            string[] dns = model.DNSList.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (dns.Length > 0)
            {
                for (int i = 0; i < dns.Length; i++)
                {
                    if (i == 0)
                    {
                        commands.Add(string.Format(NETSH_DNS, model.NetworkName, dns[i]));
                    }
                    else
                    {
                        commands.Add(string.Format(NETSH_DNS_ADD, model.NetworkName, dns[i], i));
                    }
                }
            }
            else
            {
                commands.Add(string.Format(NETSH_DNS_DHCP, model.NetworkName));
            }

            return commands;
        }


    }
}
