using System;

namespace Ids.Common
{
	public interface IReportAgent
	{
		//void ReportPacketCaptured(Packet packet, DateTime captureTime, Guid sensorId);

		void ReportPacketCaptured(NetworkEventArgs args);
	}
}