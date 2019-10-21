using System.Net.NetworkInformation;

namespace Ids.Common
{
	public interface IDataAgent
	{
		void SaveAlert(NetworkEventArgs args);
		//NetworkEventArgs ReadAlert();
		int CountAlerts();
	}
}