﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Ids.Data;

namespace Ids.Data
{
    /// <summary>
    /// Handles data access with the SensorHeartbeatLog table
    /// </summary>
    public class SensorHeartbeatDbAgent
    {

        public static int InsertHeartbeatEvent(string sensorId)
        {
            var alert = new SensorHeartBeatLog() { SensorId = sensorId, Created = DateTime.Now};
            using (var db = new DataContext())
            {
                db.SensorHeartBeatLogs.Add(alert);
                db.SaveChanges();
            }
            return alert.LogId;
        }
        public static int InsertHeartbeatEvent(string connectionString, string sensorId)
        {
            int result = 0;
            string query = "INSERT INTO dbo.SensorHeartbeatLog (SensorId, Created) " +
                   "VALUES (@SensorId, @Created) ";

            // create connection and command
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@SensorId", SqlDbType.VarChar, 50).Value = sensorId;
                    cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = DateTime.Now;

                    // open connection, execute INSERT, close connection
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return result;
        }
    }
}
