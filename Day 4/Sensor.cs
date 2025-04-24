using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sensors
{
    abstract class Sensor
    {
        public string SensorID{get; set;}
        public string SensorType{get; set;}

        public bool IsActive {get; set;}
        protected List<double> Readings =new List<double>();

        private object lockObj=new object();

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
            lock(lockObj)
            {
               Readings.Add(value);
            }
            return value;
        }

        //LINQ- Get Average,Min,Max Reading
        public double GetAverageReading()
        {
            lock(lockObj)
            {
                return Readings.Any()?Readings.Average():0;
            }
        }
        
        public double GetMinReading() 
        {
            lock(lockObj)
            {
                return Readings.Any()?Readings.Min():0;
            }
        }

        public double GetMaxReading() 
        {
            lock(lockObj)
            {
                return Readings.Any()?Readings.Max():0;
            }
        }
    }
}
