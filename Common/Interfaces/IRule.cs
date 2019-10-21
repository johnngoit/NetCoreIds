using System;

namespace Ids.Common.Interfaces
{
    public interface IRule
	{
		bool Match(NetworkEventArgs packet);
	}

	public interface IPayloadTextRule : IRule
	{
		bool Match(string message);
	}

	public interface IIpRouteRule : IRule
	{
		bool Match(string srcIp, string destIp);
	}
}