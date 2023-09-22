using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator prompts = new PromptGenerator();
        prompts._prompts.Add("What is something new I learned today?");
        prompts._prompts.Add("What is a good thing I did today?");
        prompts._prompts.Add("What '*Chef kiss' moment did I have today?");
        prompts._prompts.Add("What was an an unexpected happening today?");
        prompts._prompts.Add("What was the best part of my day?");

        Journal journal = new Journal();
        int currentAction = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while (currentAction != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write an entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Load Journal from a file");
            Console.WriteLine("4. Save Journal to a file");
            Console.WriteLine("5. Quit program");
            Console.WriteLine("6. Prompts Menu");
            Console.Write("What would you like to do? ");
            currentAction = int.Parse(Console.ReadLine());

            switch(currentAction)
            {
                case 1:
                {
                    DateTime today = DateTime.Now;
                    string todayText = today.ToShortDateString();
                    string prompt = prompts.GetRandomPrompt();

                    Console.WriteLine(prompt);
                    Console.Write(">");
                    string response = Console.ReadLine();

                    Entry entry = new Entry();
                    entry._date = todayText;
                    entry._prompt = prompt;
                    entry._response = response;
                    journal.AddEntry(entry);

                    break;
                }
                case 2:
                {
                    journal.Display();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("What is the filename?");
                    string fileName = Console.ReadLine();
                    journal.LoadFromFile(fileName);
                    break;
                }
                case 4:
                {
                    Console.WriteLine("What is the filename?");
                    string fileName = Console.ReadLine();
                    journal.SaveToFile(fileName);
                    break;
                }
                case 5:
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                case 6:
                {
                    while(currentAction != 0)
                    {
                        Console.WriteLine("Please select a menu:");
                        Console.WriteLine("0. Return to main menu");
                        Console.WriteLine("1. Add Prompts");
                        Console.WriteLine("2. View Prompts");
                        Console.WriteLine("3. Load Prompts from file");
                        Console.WriteLine("4. Save Prompts to file");
                        Console.Write("What would you like to do? ");
                        currentAction = int.Parse(Console.ReadLine());

                        switch(currentAction)
                        {
                            case 0:
                            {
                                break;
                            }
                            case 1:
                            {
                                Console.WriteLine("What prompt will you add?");
                                string newPrompt = Console.ReadLine();
                                prompts._prompts.Add(newPrompt);
                                break;
                            }
                            case 2:
                            {
                                prompts.Display();
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("What is the file name?");
                                string fileName = Console.ReadLine();
                                prompts.LoadFromFile(fileName);
                                break;
                            }
                            case 4:
                            {
                                Console.WriteLine("What is the file name?");
                                string fileName = Console.ReadLine();
                                prompts.SaveToFile(fileName);
                                break;
                            }
                            default:
                            {
                                Console.WriteLine($"Your input '{currentAction}' is not a valid choice. Try again");
                                break;
                            }
                        }
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine($"Your input '{currentAction}' is not a valid choice. Try again.");
                    break;
                }
            }
        }
    }
}