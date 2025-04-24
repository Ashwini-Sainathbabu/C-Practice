namespace AssemblyLineSimulationModular
{
    public static class ConveyorFactory
    {
        public static Conveyor CreateInputConveyor() => new Conveyor
        {
            Name = "Input Conveyor",
            Components = new List<Component>{
                new Sensor {Name ="Input Sensor"},
                new Motor {Name ="Input Motor"}
            }
        };

        public static Conveyor CreateInspectionConveyor() => new Conveyor
        {
            Name = "Inspection Conveyor",
            Components = new List<Component>
            {
                new Cylinder {Name="Flipping Cyclinder"}
            }
        };

         public static Conveyor CreateOutputConveyor() =>
            new Conveyor
            {
                Name = "Output Conveyor",
                Components = new List<Component>
                {
                    new Motor { Name = "Output Motor" }
                }
            };

        public static Conveyor CreateRejectConveyor() =>
           new Conveyor
           {
               Name = "Reject Conveyor",
               Components = new List<Component>
               {
                    new Cylinder { Name = "Reject Arm Cylinder" }
               }
           };

    }
}