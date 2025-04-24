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
         Console.WriteLine($"--- {DeviceName} Sensor Readings ---");
        foreach (var sensor in Sensors)
        {
            double reading=sensor.GetReading();
            System.Console.WriteLine($"Sensor {sensor.SensorType} Reading:{reading}");
        }
    }

    //LINQ -Get Average Temperature reading
    public double GetAverageTemperature()
    {
        //Filtering with ofType: We use the OfType<Dog>() method to filter out only the Dog objects from the list.
        var tempSensors=Sensors.OfType<TemperatureSensor>().ToList();
        return tempSensors.Any()?tempSensors.Average(s=>s.GetAverageReading()):0;
    }

    public void DisplaySensorStats()
    {
        System.Console.WriteLine($"\n--- {DeviceName} Sensor Statistics ---");
        foreach (var sensor in Sensors)
        {
            Console.WriteLine($"Sensor {sensor.SensorType}: Min: {sensor.GetMinReading()}, Max: {sensor.GetMaxReading()}, Avg: {sensor.GetAverageReading()}");
        }   
    }
}