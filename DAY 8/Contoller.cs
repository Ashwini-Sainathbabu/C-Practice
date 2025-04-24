namespace AssemblyLineSimulationModular
{
    public class Controller
    {
        private readonly Conveyor _inputConveyor;
        private readonly Conveyor _inspectionConveyor;
        private readonly Camera _camera;
        private readonly InspectionSystem _inspectionSystem;

        public Controller()
        {
            _inputConveyor= ConveyorFactory.CreateInputConveyor();
            _inspectionConveyor=ConveyorFactory.CreateInspectionConveyor();
             Conveyor outputConveyor = ConveyorFactory.CreateOutputConveyor();
             Conveyor rejectConveyor = ConveyorFactory.CreateRejectConveyor();

             _camera=new Camera{Name ="Inspection Camera"};
             _inspectionSystem=new InspectionSystem(_camera,outputConveyor,rejectConveyor);

        }

        public async Task ProcessSubassemblyAsync()
        {
            _inputConveyor.Start();
            _inspectionConveyor.Start();
            _inspectionSystem.Inspect();
            await Task.Delay(1000);
        }

    }
    
}