using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid input. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
