using System.Net.NetworkInformation;

namespace Common
{
	public interface IDataAgent
	{
		void SaveEFAlert(NetworkEventArgs args);
		//NetworkEventArgs ReadAlert();
		int CountAlerts();
	}
}