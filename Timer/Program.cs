using System;
using System.Threading;

namespace TimerVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            while (runProgram)
            {
                Console.WriteLine("How long would you like your timer to be?");
                string input = Console.ReadLine();

                // Convert the input to a float
                if (float.TryParse(input, out float timerInput))
                {
                    // Run timer in a separate thread
                    Thread timerThread = new Thread(() => RunTimer(timerInput));
                    timerThread.Start();

                    Console.WriteLine("Setting timer for " + timerInput + " seconds. Press Enter to exit.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine("Do you want to start a new timer? (y/n)");
                string response = Console.ReadLine();

                // Check if the user wants to start a new timer
                runProgram = (response.ToLower() == "y");
            }
        }

        static void RunTimer(float seconds)
        {
            Console.WriteLine($"Timer set for {seconds} seconds.");

            for (int i = (int)seconds; i > 0; i--)
            {
                Console.WriteLine($"Time remaining: {i} seconds");
                Thread.Sleep(1000); // Sleep for 1 second
            }

            Console.WriteLine("Timer expired!");

            // Simulate a pop-up message within the console
            Console.WriteLine("Pop-up message: Time is up!");
        }
    }
}