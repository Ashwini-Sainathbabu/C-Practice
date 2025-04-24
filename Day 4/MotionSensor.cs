namespace Sensors
{
    class MotionSensor:Sensor
    {
        private Random random =new Random();

        public MotionSensor(string id):base(id,"Motion")
        {

        }

        public override double ReadValue()
        {
            Thread.Sleep(100); //simulate delay
            return random.Next(0,2);
        }
    }
}