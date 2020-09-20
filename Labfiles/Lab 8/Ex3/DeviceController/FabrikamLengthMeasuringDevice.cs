using DeviceControl;
using System;

namespace Fabrikam.Devices.MeasuringDevices
{
    class LengthMeasuringDevice : IControllableDevice
    {
        Random random;

        public LengthMeasuringDevice()
        {
            random = new Random();
        }

        public void StartDevice()
        {
            // Start the device.           
        }

        public void StopDevice()
        {
            // Stop the device.
        }

        public int GetLatestMeasure()
        {
            return random.Next(1000);
        }
    }
}