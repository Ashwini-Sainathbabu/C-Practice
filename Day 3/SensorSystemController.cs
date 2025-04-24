using System.Collections.Generic;

class SensorSystemController
{
    private List<Device> devices =new List<Device>();

    public void AddDevice(Device device)
    {
        devices.Add(device);
        System.Console.WriteLine($"Device {device.DeviceName} added to system");
    }

    public void DisplayDeviceData()
    {
        foreach (var device in devices)
        {
            System.Console.WriteLine($"Device {device.DeviceName} - ID:{device.DeviceID}");
            device.ReadAllSensors();
            device.DisplaySensorStats();
        }
    }
}