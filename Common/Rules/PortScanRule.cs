using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ids.Common;
using Ids.Common.Interfaces;

namespace Ids.Common.Rules
{
	public class PortScanRule : IRule
	{
		private int threatThreshold;
		private string protectedHost;

		private List<int> portsSeen;

		public PortScanRule(string protectedHostAddress, int numberOfPortsThreshold)
		{
			portsSeen = new List<int>();
			threatThreshold = numberOfPortsThreshold;
			protectedHost = protectedHostAddress;
		}
		public bool Match(NetworkEventArgs packet)
		{
			if ( packet.DestinationIpAddress == protectedHost)
			{
				if (!portsSeen.Contains(packet.DestinationPort))
				{
					portsSeen.Add(packet.DestinationPort);
				}
			}
			return (portsSeen.Count >= threatThreshold);
		}
	}
}
