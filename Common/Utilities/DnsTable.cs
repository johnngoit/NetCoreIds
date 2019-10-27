using System;
using System.Net;
using System.Collections;

namespace Common.Utilities
{
	/// <summary>
	/// Summary description for DnsTable.
	/// </summary>
	public class DnsTable
	{
		public static Hashtable DnsNames_  = null;
		static DnsTable()
		{
			DnsNames_ = new Hashtable();
		}
		public static string GetName(string ip)
		{
			if(!DnsNames_.Contains(ip)){
				try
				{
					IPHostEntry tmp = Dns.GetHostByAddress(ip);					
					if (!DnsNames_.Contains(ip))
						DnsNames_.Add(ip,tmp.HostName);
				}
				catch(Exception)
				{
					if (!DnsNames_.Contains(ip))
						DnsNames_.Add(ip,ip);
				}
			}
			return (string)DnsNames_[ip];
		}


        //var address = Dns.GetHostAddresses("www.test.com")[0];
        public static IPAddress[] GetIpAddresses(string domainName) {
            return Dns.GetHostAddresses(domainName);
        }
	}
}
