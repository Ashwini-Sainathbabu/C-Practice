namespace AssemblyLineSimulationModular
{
    public class InspectionSystem
    {
        private readonly Camera _camera;
        private readonly Conveyor _outputConveyor;
        private readonly Conveyor _rejectConveyor;

        public InspectionSystem(Camera camera,Conveyor outputConveyor ,Conveyor rejectConveyor){
            _camera=camera;
            _outputConveyor=outputConveyor;
            _rejectConveyor =rejectConveyor;
            _camera.InspectionCompleted +=HandleInspectionResult;
        }

        public void Inspect()=> _camera.Activate();

        private void HandleInspectionResult(object sender ,bool isPassed)
        {
            if(isPassed)
            {
                _outputConveyor.Start();
            }
            else
            {
                _rejectConveyor.Start();
            }
        }
    }
}