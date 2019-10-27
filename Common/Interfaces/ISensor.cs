using System;
namespace Common.Interfaces
{
    public interface ISensor
    {
        IInformationSource InformationSource { get; set; }
        void StartCapturing();
        void StopCapturing();

        string GetSensorId();
    }
}
