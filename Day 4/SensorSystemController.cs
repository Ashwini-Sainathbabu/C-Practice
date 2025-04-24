using System.Collections.Generic;

class SensorSystemController
{
    private List<Device> devices =new List<Device>();

    public void AddDevice(Device device)
    {
        devices.Add(device);
        System.Console.WriteLine($"Device {device.DeviceName} added to system");
    }

    /*public void DisplayDeviceData()
    {
        foreach (var device in devices)
        {
            System.Console.WriteLine($"\n Device {device.DeviceName} - ID:{device.DeviceID}");
            device.DisplaySensorStats();
        }
    }*/

    public async Task DisplayDeviceDataAsync()
    {
        var tasks=devices.Select(device=>device.ReadAllSensorsAsync());
        await Task.WhenAll(tasks);
        foreach(var device in devices)
        {
           device.DisplaySensorStats(); 
        }
    }
}