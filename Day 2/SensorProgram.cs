using Sensors;

class SensorProgram
{
    static void Main()
    {
        TemperatureSensor tempSensor1 =new TemperatureSensor("T001");
        MotionSensor motionSensor1=new MotionSensor("M001");

        Device smartHomeDevice =new Device("D001","SmartHomeController");

        smartHomeDevice.AddSensor(tempSensor1);
        smartHomeDevice.AddSensor(motionSensor1);

        SensorSystemController controller=new SensorSystemController();
        controller.AddDevice(smartHomeDevice);
        controller.DisplayDeviceData();
        
        System.Console.WriteLine($"The sensor is:{tempSensor1.IsActive}");
        tempSensor1.Deactivate();
        System.Console.WriteLine($"Now the temperature sensor is:{tempSensor1.IsActive}");
        System.Console.WriteLine($"Now the motion sensor is:{motionSensor1.IsActive}");
    }
}