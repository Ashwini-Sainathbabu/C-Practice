using System;

namespace Sensors
{
    abstract class Sensor
    {
        public string SensorID{get; set;}
        public string SensorType{get; set;}

        public bool IsActive {get; set;}

        public Sensor(string id,string type)
        {
            SensorID=id;
            SensorType=type;
            IsActive=true;
        }

        public abstract double ReadValue();

        public void Activate()=>IsActive=true;
        public void Deactivate()=>IsActive=false;
    }
}
