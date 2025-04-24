using System;

class TemperatureSensorEvent
{
  
//   Defines the signature of event handler methods
  public delegate void ThresholdReachedEventHandler (object sender,EventArgs e);
// event declaration
  public event ThresholdReachedEventHandler? ThresholdReached;

  private int _temperature;

  public int Temperature
  {
    get{return _temperature;}
    set{
        _temperature=value;
        if(_temperature>30)
        {
            onThresholdReached(EventArgs.Empty);
        }
    }
  }

  public  void onThresholdReached(EventArgs e)
  {
      if (ThresholdReached != null)
            ThresholdReached(this, e);
    /* 
    sender -->	The object that raised (triggered) the event
     e     -->  The event data (extra information, like the temperature value or just EventArgs.Empty)
     */
  }  
}

class EventProgram
{
    static void Main()
    {
       
        TemperatureSensorEvent sensor =new TemperatureSensorEvent();
        sensor.ThresholdReached += Sensor_ThreadholdReached;  //Assignning eventHandler to event.
        
        // event Handler using a lambda expression
        sensor.ThresholdReached += (sender, e) =>
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Lambda] Warning: Temperature is too high!");
            Console.ResetColor();
        };

         Console.WriteLine("Setting temperature to 25...");
        sensor.Temperature = 25;

        Console.WriteLine("Setting temperature to 35...");
        sensor.Temperature = 35;
        
    }
    
    // event handler
    private static void Sensor_ThreadholdReached(object sender,EventArgs e)
    {
         Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Alert: Temperature threshold exceeded!");
        Console.ResetColor();
    }
}