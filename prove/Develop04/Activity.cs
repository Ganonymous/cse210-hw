public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    protected Activity(){}

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = GetUserDuration();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);
    }

    private int GetUserDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        return int.Parse(Console.ReadLine());
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int runTime)
    {
        int spinSteps = runTime * 4;
        List<char> spinChars = new List<char>();
        spinChars.Add('|');
        spinChars.Add('/');
        spinChars.Add('-');
        spinChars.Add('\\');
        for(int i = 0; i < spinSteps; i++)
        {
            Console.Write(spinChars[i % spinChars.Count]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    public void ShowCountDown(int runTime)
    {
        Console.Write(runTime);
        string removalString = runTime < 10 ? "\b \b" : "\b\b  \b\b";
        runTime--;
        Thread.Sleep(1000);
        
        Console.Write(removalString);
        if(runTime > 0)
        {
            ShowCountDown(runTime);
        }
    }
}