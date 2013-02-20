using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace denolk.netcf.Model
{
    public class NetworkConfigModel
    {
        public string ProfileName { get; set; }
        public string InterfaceName { get; set; }
        public string NetworkName { get; set; }
        public string IpAddress { get; set; }
        public string Subnet { get; set; }
        public string Gateway { get; set; }
        public string DNSList { get; set; }
        public bool UseDHCP { get; set; }

        public NetworkConfigModel() { }

        public NetworkConfigModel(NetworkInterface ni)
        {
            var ip = ni.GetIPProperties();
            this.IpAddress = ip.UnicastAddresses.Count > 0 ? ip.UnicastAddresses[0].Address.ToString() : "";
            this.Gateway = ip.GatewayAddresses.Count > 0 ? ip.GatewayAddresses[0].Address.ToString() : "";
            this.Subnet = ip.UnicastAddresses.Count > 0 ? ip.UnicastAddresses[0].IPv4Mask.ToString() : "";
            this.DNSList = ip.DnsAddresses.Count > 0 ? string.Join(";", ip.DnsAddresses.Select(dn => dn.ToString())) : "";
            this.NetworkName = ni.Name;
            this.InterfaceName = ni.Description;
            this.UseDHCP = string.IsNullOrEmpty(this.IpAddress) && string.IsNullOrEmpty(this.Gateway);
        }


        public override string ToString()
        {
            return this.ProfileName;
        }
    }
}
