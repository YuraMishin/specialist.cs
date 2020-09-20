using DeviceControl;
using System;

namespace Contoso.MeasuringDevices
{
    class MassMeasuringDevice : IControllableDevice
    {
        Random random;

        public MassMeasuringDevice()
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
            return random.Next(1390);
        }
    }
}