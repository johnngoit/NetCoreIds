using System;
using Common;
using Common.Interfaces;

namespace Common.Rules
{
	public class ThoughputRule : IRule
	{
		private readonly int threadThreshold;
        private int packetsSeen;

        private DateTime firstPacketSeen;
        private DateTime lastPacketSeen;
		public ThoughputRule(int numberPacketsThreshold)
		{
            packetsSeen = 0;
			threadThreshold = numberPacketsThreshold;
		}

		public bool Match(NetworkEventArgs packet)
		{
			if (packetsSeen == 0)
                firstPacketSeen = DateTime.Now;
            packetsSeen++;
            if(packetsSeen == threadThreshold){
                lastPacketSeen = DateTime.Now;
                TimeSpan diff = lastPacketSeen - firstPacketSeen;
                if (diff.Milliseconds < 1000)
                    return true;
            }
            return false;
		}
	}
}