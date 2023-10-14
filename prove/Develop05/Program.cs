using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int userAction = 0;
        while (userAction != 7)
        {
            manager.DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu options");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Edit Your Info");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            userAction = int.Parse(Console.ReadLine());
            switch (userAction)
            {
                case 1:
                    manager.CreateGoal();
                    break;
                case 2:
                    manager.ListGoalDetails();
                    break;
                case 3:
                    manager.SaveToFile();
                    break;
                case 4:
                    manager.LoadFromFile();
                    break;
                case 5:
                    manager.RecordEvent();
                    break;
                case 6:
                    while (userAction != 0)
                    {
                        Console.WriteLine("User Info Menu:");
                        Console.WriteLine("  0. Return to Main Menu");
                        Console.WriteLine("  1. Edit Username");
                        Console.WriteLine("  2. Change Class");
                        Console.WriteLine("  3. Edit Exp Progression");
                        Console.Write("Select a choice from the menu: ");
                        userAction = int.Parse(Console.ReadLine());
                        switch (userAction)
                        {
                            case 0:
                                break;
                            case 1:
                                manager.UpdateName();
                                break;
                            case 2:
                                manager.UpdateClass();
                                break;
                            case 3:
                                manager.UpdateProgression();
                                break;
                            default:
                                Console.WriteLine($"Your input '{userAction}' does not match a menu option. Try again.");
                                break;
                        }
                    }
                    break;
                case 7:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine($"Your input '{userAction}' does not match a menu option. Try again.");
                    break;
            }
        }
    }
}