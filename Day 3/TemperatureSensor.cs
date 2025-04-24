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
            return random.Next(15,35);
        }
    }
}