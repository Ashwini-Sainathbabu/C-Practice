namespace AssemblyLineSimulationModular
{
    public delegate void InspectionCompletedHandler(object sender,bool isPassed);

    public class Camera :Component
    {
        public event InspectionCompletedHandler InspectionCompleted;

        public override void Activate()
        {
            System.Console.WriteLine($"{Name}: Capturing image..");
            Thread.Sleep(500);
            bool result =new Random().Next(0,2)==1;
            System.Console.WriteLine($"{Name}: Inspection {(result ? "Passed":"Failed")}");
            InspectionCompleted?.Invoke(this,result);
        }
    }
}