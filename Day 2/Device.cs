using System.Collections.Generic;
using Sensors;

class Device
{
    public string DeviceID{get; set;}
    public string DeviceName{get; set;}
    private List<Sensor> Sensors=new List<Sensor>();

    public Device(string id,string name)
    {
        DeviceID=id;
        DeviceName=name;
    }

    public void AddSensor(Sensor sensor)
    {
        Sensors.Add(sensor);
        System.Console.WriteLine($"Sensor{sensor.SensorType}");
    }

    public void ReadAllSensors()
    {
        foreach (var sensor in Sensors)
        {
            System.Console.WriteLine($"Sensor {sensor.SensorType} Reading:{sensor.ReadValue()}");
        }
    }
}