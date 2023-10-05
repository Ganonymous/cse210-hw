using System;

class Program
{
    
    static void Main(string[] args)
    {
        StatTracker tracker = new StatTracker();
        Console.Clear();
        int nextAction = 0;
        while (nextAction != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View session statistics");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            nextAction = int.Parse(Console.ReadLine());

            switch (nextAction)
            {
                case 1:
                    BreathingActivity ba = new BreathingActivity();
                    ba.Run(tracker);
                    break;
                case 2:
                    ReflectingActivity ra = new ReflectingActivity();
                    ra.Run(tracker);
                    break;
                case 3:
                    ListingActivity la = new ListingActivity();
                    la.Run(tracker);
                    break;
                case 4:
                    tracker.DisplayStats();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine($"Your choice '{nextAction}' is not a valid menu option. Try again.");
                    break;
            }

        }
    }
}