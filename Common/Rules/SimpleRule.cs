using Common;
using Common.Interfaces;

namespace Common.Rules
{
	public class SimpleRule : IPayloadTextRule
	{
		private readonly string matchPattern;
		public SimpleRule(string pattern)
		{
			matchPattern = pattern;
		}
		public bool Match(string message)
		{
			return (message.Contains(matchPattern));
		}

		public bool Match(NetworkEventArgs packet)
		{
			return Match(packet.PayloadText);
		}
	}
}