using System.Net.NetworkInformation;

namespace Common
{
	public interface IDataAgent
	{
		void SaveAlert(NetworkEventArgs args);
		//NetworkEventArgs ReadAlert();
		int CountAlerts();
	}
}