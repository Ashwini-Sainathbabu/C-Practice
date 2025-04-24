namespace AssemblyLineSimulationModular
{
    public class Conveyor
    {
        public string Name {get; set;}

        public List<Component> Components {get;set;}=new();

        public void Start()
        {
            System.Console.WriteLine($"\n== {Name} Started==");
            foreach(var comp in Components)
            {
                comp.Activate();
            }
        }
    }
}