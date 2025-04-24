using Sensors;

class SensorProgram
{
    static  async Task Main()
    {
        try
        {
            TemperatureSensor tempSensor1 = new TemperatureSensor("T001");
            MotionSensor motionSensor1 = new MotionSensor("M001");

            Device smartHomeDevice = new Device("D001", "SmartHomeController");

            smartHomeDevice.AddSensor(tempSensor1);
            smartHomeDevice.AddSensor(motionSensor1);

            SensorSystemController controller = new SensorSystemController();
            controller.AddDevice(smartHomeDevice);


            // Read Data Multiple Times
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nReading Cycle {i + 1}:");
                await smartHomeDevice.ReadAllSensorsAsync();
            }

            Console.WriteLine("\n📊 Final Device Statistics:");
            await controller.DisplayDeviceDataAsync();
            
            //Filtering Data using LINQ 
            System.Console.WriteLine($"This is Average temperature:{smartHomeDevice.GetAverageTemperature()}");

            System.Console.WriteLine($"\n The sensor is:{tempSensor1.IsActive}");
            tempSensor1.Deactivate();
            System.Console.WriteLine($"Now the temperature sensor is:{tempSensor1.IsActive}");
            System.Console.WriteLine($"Now the motion sensor is:{motionSensor1.IsActive}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("System execution completed.");
        }
    }
}