using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Common;
using Common.Interfaces;

namespace Common.Rules
{
	public class HostScanRule : IIpRouteRule
	{
		private int numberOfTargets;

		private Dictionary<string, List<string>> routesSeen;

		public HostScanRule(int numberOfTargetHosts)
		{
			routesSeen = new Dictionary<string, List<string>>();
			numberOfTargets = numberOfTargetHosts;
		}

		public bool Match(NetworkEventArgs packet)
		{
			return this.Match(packet.SourceIpAddress, packet.DestinationIpAddress);
		}

		public bool Match(string srcIp, string destIp)
		{
			if (!routesSeen.ContainsKey(srcIp))
			{
				List<string> hostsTargetted = new List<string>();
				routesSeen.Add(srcIp, hostsTargetted);
			}
			if (!routesSeen[srcIp].Contains(destIp))
				routesSeen[srcIp].Add(destIp);

			int maxNumberOfTargetsSeen = routesSeen.Max(x => x.Value.Count);
			return (maxNumberOfTargetsSeen >= numberOfTargets);
		}
	}
}