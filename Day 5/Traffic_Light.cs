using System.Threading;

class TrafficLight
{
    // Enum to represent the states of the traffic light
    enum LightState
    {
        Red,
        Yellow,
        Green
    }

    static void Main()
    {
        // Initializing the current state to Red
        LightState currentState =LightState.Red;

        //To execute the process repeatively
        while(true)
        {
            switch(currentState)
            {
                case LightState.Red:
                    showLight("RED" ,ConsoleColor.Red,45); // Show the red light for 45 seconds
                    currentState =LightState.Yellow; //change the state after the time over to yellow
                    break;
                case LightState.Yellow:
                    showLight("Yellow" ,ConsoleColor.Yellow,5); //Show the Yellow light for 5 seconds
                    currentState =LightState.Green; //change the state after the time over to green
                    break;
                case LightState.Green:
                    showLight("GREEN", ConsoleColor.Green, 30);  //Show the Green light for 30 seconds
                    currentState = LightState.Red; //change the state after the time over to Red
                    break;
            }
        }
    }

    // Method to display the light and its duration

    static void showLight(string lightName,ConsoleColor color,int durationInSeconds)
    {
        Console.Clear(); //to show current light and count down
        Console.ForegroundColor = color; // used to change the color of the text displayed in the console.

        System.Console.WriteLine($"=== {lightName} LIGHT ON ===");
        for (int i = durationInSeconds; i > 0; i--)
        {
            Console.Write($"\rTime left: {i} seconds "); //(/r) - used to update the countdown timer on the same line
            Thread.Sleep(1000);
        }

        Console.ResetColor();
    }
}