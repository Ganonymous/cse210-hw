public class ListingActivity: Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;
        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run(StatTracker tracker)
    {
        DisplayStartingMessage();
        DisplayRandomPrompt();
        _count = GetListFromUser(_duration);
        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();
        DisplayEndingMessage();
        tracker.RecordListing(_duration, _count);
    }

    private void DisplayRandomPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[new Random().Next(_prompts.Count)]} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
    }
    private int GetListFromUser(int runTime)
    {
        DateTime endTime = DateTime.Now.AddSeconds(runTime);
        int responses = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if(response.Length != 0)
            {
                responses++;
            }
        }
        return responses;
    }
}