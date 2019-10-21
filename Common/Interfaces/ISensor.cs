using System;
namespace Ids.Common.Interfaces
{
    public interface ISensor
    {
        IInformationSource InformationSource { get; set; }
        void StartCapturing();
        void StopCapturing();

        string GetSensorId();
    }
}
