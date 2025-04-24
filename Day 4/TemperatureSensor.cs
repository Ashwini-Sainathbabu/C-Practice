namespace Sensors
{
    class TemperatureSensor:Sensor
    {
        private Random random =new Random();

        public TemperatureSensor(string id):base(id,"Temperature")
        {

        }

        public override double ReadValue()
        {
            Thread.Sleep(200); //stimulation delay
            return random.Next(15,35);
        }
    }
}