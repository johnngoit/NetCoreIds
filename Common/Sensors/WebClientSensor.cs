using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Ids.Common.Interfaces;
using SharpPcap;

namespace Ids.Common.Sensors
{
    public class WebClientSensor : BaseSensor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceToCaptureInfo"></param>
        /// <param name="filter"></param>
        /// <param name="deviceMode"></param>
        /// <param name="reportMethods"></param>
        /// <param name="heartBeatDelay"></param>
        /// <param name="timeWindow">How big is the window we measure for a DoS attack</param>
        /// 
        /// 
        private WebClientSensor(CaptureDeviceDescription deviceToCaptureInfo, string filter, DeviceMode deviceMode, List<ISensorReport> reportMethods, int heartBeatDelay)
            : base(deviceToCaptureInfo, filter, deviceMode, reportMethods, heartBeatDelay, Enumerations.SensorMode.PacketCapture)
        {
        }
        public static WebClientSensor FactoryMethod(CaptureDeviceDescription deviceToCaptureInfo,string[] webServers, int port, bool sensorDeployedOnWebServer, List<ISensorReport> reportMethods, int heartBeatDelay)
        {
            List<string> webFilter = new List<string>();//string.Format("((dst net {0}) and (dst port {1}))", webServerAdress, port);
            //string webFilter = string.Format("dst net {0}", webServerAdress);
            // for each webserver need the ipaddress
            foreach(string ad in webServers){
                webFilter.Add(string.Format("host {0}", ad.ToString()));
            }
            
            DeviceMode sensorListeningMode = DeviceMode.Promiscuous;
            //string webFilter = "port 80";

            if (sensorDeployedOnWebServer) sensorListeningMode = DeviceMode.Normal;

            return new WebClientSensor(deviceToCaptureInfo,String.Join(" and ", webFilter.ToArray()), sensorListeningMode, reportMethods, heartBeatDelay);
        }     
    }
}
