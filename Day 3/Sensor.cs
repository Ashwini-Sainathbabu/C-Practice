using System;

namespace Sensors
{
    abstract class Sensor
    {
        public string SensorID{get; set;}
        public string SensorType{get; set;}

        public bool IsActive {get; set;}
        protected List<double> Readings =new List<double>();

        public Sensor(string id,string type)
        {
            SensorID=id;
            SensorType=type;
            IsActive=true;
        }

        public abstract double ReadValue();

        public void Activate()=>IsActive=true;
        public void Deactivate()=>IsActive=false;

       //storing reading in  a list and returing value
        public double GetReading()
        {
            double value =ReadValue();
            Readings.Add(value);
            return value;
        }

        //LINQ- Get Average,Min,Max Reading
        public double GetAverageReading()=> Readings.Any()?Readings.Average():0;
        public double GetMinReading()=> Readings.Any()?Readings.Min():0;
        public double GetMaxReading()=> Readings.Any()?Readings.Max():0;
    }
}
