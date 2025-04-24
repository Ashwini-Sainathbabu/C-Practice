using Sensors;

class Device
{
    public string DeviceID{get; set;}
    public string DeviceName{get; set;}
    private List<Sensor> Sensors=new List<Sensor>();

    private object consoleLock =new object();

    public Device(string id,string name)
    {
        DeviceID=id;
        DeviceName=name;
    }

    public void AddSensor(Sensor sensor)
    {
        Sensors.Add(sensor);
        System.Console.WriteLine($"Sensor {sensor.SensorType}");
    }

    //Async parallel sensor Reading
    /*  Console.WriteLine($"--- {DeviceName} Sensor Readings ---");
         foreach (var sensor in Sensors)
         {
             double reading=sensor.GetReading();
            System.Console.WriteLine($"Sensor {sensor.SensorType} Reading:{reading}");
        }   SYNC CODE
        */
    //It reads all the sensors at the same time (in parallel) using tasks, waits until they’re done, and then continues.
    public async Task ReadAllSensorsAsync()
    {
         var tasks=Sensors.Select(sensor=> Task.Run(()=>{
             double reading =sensor.GetReading();
             lock(consoleLock)
             {
                 System.Console.WriteLine($"[{DeviceName}] Sensor {sensor.SensorType} Reading:{reading}");
             }
         }));

         await Task.WhenAll(tasks);
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