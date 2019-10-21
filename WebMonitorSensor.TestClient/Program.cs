using System;
using System.Net;
using System.Collections.Generic;
using Ids.Common;
using Ids.Common.Reporters;
using Ids.Common.Sensors;
using Ids.Common.Interfaces;
using Ids.Common.Utilities;

namespace Ids.Client.WebMonitorSensor.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISensorReport> reporters = new List<ISensorReport>();
            reporters.Add(new SimpleReportAgent());
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IDSDB;Persist Security Info=True;User ID=cyberproduct;Password=x2000; Connect Timeout=600;Max Pool Size = 200;Pooling = True";

            AzureSqlDbReportAgent cloudDbReportAgent = new AzureSqlDbReportAgent(connectionString, String.Empty);

            reporters.Add(cloudDbReportAgent);
            CaptureDeviceDescription cdd = new CaptureDeviceDescription()
            {
                DeviceNumber = 0,
                TextInDeviceName = "whatever"
            };

            
            //www.google.com = 216.58.209.100
            //const string googleIpAddress = "216.58.209.100";
            List<string> webServers = new List<string>();
            //webServers.Add("www.google.com");
            webServers.Add("www.youtube.com");
            //webServers.AddRange(DnsTable.GetIpAddresses("www.youtube.com"));
            WebClientSensor wds = WebClientSensor.FactoryMethod(cdd, webServers.ToArray(), 443, false, reporters, 5000);
            cloudDbReportAgent.UpdateSensorId(wds.GetSensorId());
            wds.StartCapturing();
            Console.ReadLine();
            wds.StopCapturing();

            //const string ftpIpAddress = "192.168.1.74";
            //FtpServerDosSensor fds = FtpServerDosSensor.FactoryMethod(cdd, ftpIpAddress, 443, false, reporters, 5000);
            //cloudDbReportAgent.UpdateSensorId(fds.GetSensorId());
            //fds.StartCapturing();
            //Console.ReadLine();
            //fds.StopCapturing();
        }
    }
}
