namespace DeviceControl
{
    interface IControllableDevice
    {
        void StartDevice();
        void StopDevice();
        int GetLatestMeasure();
    }
}