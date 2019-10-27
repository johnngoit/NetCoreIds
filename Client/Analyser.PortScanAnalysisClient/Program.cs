using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Analysers;
using Data;
using Common.Interfaces;
using Common.Reporters;

namespace Analyser.PortScanAnalysisClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IDSDB;Persist Security Info=True;User ID=cyberproduct;Password=x2000; Connect Timeout=600;Max Pool Size = 200;Pooling = True";

            //reporters
            List<IAlertReport> reporters = new List<IAlertReport>();
            //AzureSqlDbReportAgent ara = new AzureSqlDbReportAgent(connectionString);
            //reporters.Add(ara);
            reporters.Add(new Common.Reporters.SimpleReportAgent());


            //data agent
            SensorEventDbAgent dbDataAgent = new SensorEventDbAgent(connectionString);

            SimplePortScanAnalyser psa = new SimplePortScanAnalyser(reporters, 2000, dbDataAgent);

            psa.CheckForHorizontalScan(connectionString, 0, null);

        }
    }
}
