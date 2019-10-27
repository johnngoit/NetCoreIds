using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Common;
using Common.Interfaces;
using Common.Models;
using Data;

namespace Data
{
	public class EfDataAgent : IDataAgent
	{

        private string _connectionString;

        public EfDataAgent(string connectionString)
        {
            _connectionString = connectionString;
        }

		public void SaveEFAlert(NetworkEventArgs args)
		{
			//using (AlertsEntities entities = new AlertsEntities())
            using (var entities = new DataContext())
			{
				entities.Alerts.Add(new Alert()
				{
					Created = DateTime.Now,
					DatasourceId = args.DatasourceId,
					DestinationPort = args.DestinationPort,
					SourcePort = args.SourcePort,
					DestinationIp = args.DestinationIpAddress,
					SourceIp = args.SourceIpAddress,
					Payload = args.PayloadText
				});
				entities.SaveChanges();
			}
        }
		public void SaveAlert(NetworkEventArgs args)
		{
			// using (AlertsEntities entities = new AlertsEntities())
			// {
			// 	entities.Alerts.Add(new Alerts()
			// 	{
			// 		Created = DateTime.Now,
			// 		DatasourceId = args.DatasourceId,
			// 		DestinationPort = args.DestinationPort,
			// 		SourcePort = args.SourcePort,
			// 		DestinationIp = args.DestinationIpAddress,
			// 		SourceIp = args.SourceIpAddress,
			// 		Payload = args.PayloadText
			// 	});
			// 	entities.SaveChanges();
			// }
			
             int result = 0;
            string query = "INSERT INTO dbo.Alerts (DatasourceId, Sourceip, SourcePort, DestinationIp, DestinationPort, Payload, Created) " +
                   "VALUES (@DatasourceId, @SourceIp, @SourcePort, @DestinationIp, @DestinationPort,  @Payload, @Created) ";

             // create connection and command
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@DatasourceId", SqlDbType.VarChar, 50).Value = args.DatasourceId;
                    cmd.Parameters.Add("@SourceIp", SqlDbType.VarChar, 50).Value = args.SourceIpAddress;
                    cmd.Parameters.Add("@SourcePort", SqlDbType.VarChar, 50).Value = args.SourcePort;
                    cmd.Parameters.Add("@DestinationIp", SqlDbType.VarChar, 50).Value = args.DestinationIpAddress;
                    cmd.Parameters.Add("@DestinationPort", SqlDbType.Int).Value = args.DestinationPort;
                    cmd.Parameters.Add("@Payload", SqlDbType.VarChar, 255).Value = args.PayloadText; 
                    cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = DateTime.Now;

                    // open connection, execute INSERT, close connection
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
             //return result;
		}

		public int CountAlerts()
		{
			// using (AlertsEntities entities = new AlertsEntities())
			// {
			// 	return entities.Alerts.Count();
			// }
            return 0;
		}
	}
}