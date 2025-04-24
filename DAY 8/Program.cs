namespace AssemblyLineSimulationModular
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var controller=new Controller();

            System.Console.WriteLine("=====Starting subassembly inspection Line ===");

             for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\n--- Processing Subassembly #{i} ---");
                await controller.ProcessSubassemblyAsync();
            }

            Console.WriteLine("\n=== Inspection Line Stopped ===");
        }
    }
}