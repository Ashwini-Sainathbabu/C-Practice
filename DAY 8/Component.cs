using System;
using AssemblyLineSimulationModular;

namespace AssemblyLineSimulationModular
{
    public abstract class Component
    {
        public string Name { get; set; }
        public abstract void Activate();
    }

    public class Sensor : Component
    {

        public override void Activate() => Console.WriteLine($"{Name} : Sensor activated.");

    }

    public class Motor : Component
    {

        public override void Activate() => Console.WriteLine($"{Name} : Motor running.");

    }
    public class Cylinder : Component
    {

        public override void Activate() => Console.WriteLine($"{Name} : Cylinder actuated.");

    }
}