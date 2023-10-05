public class ReflectingActivity: Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("THink of a time when you did something truly selfless.");
        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different thatn other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run(StatTracker tracker)
    {
        DisplayStartingMessage();
        DisplayRandomPrompt();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            DisplayRandomQuestion();
        }
        DisplayEndingMessage();
        tracker.RecordReflecting(_duration);
    }

    private void DisplayRandomPrompt()
    {
        Console.WriteLine("Consider the following prompt: ");
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press 'enter' to continue.");
        Console.ReadLine();
    }

    private void DisplayRandomQuestion()
    {
        int questionIndex = new Random().Next(_questions.Count);
        Console.Write($"> {_questions[questionIndex]} ");
        _questions.RemoveAt(questionIndex);
        ShowSpinner(12);
        Console.WriteLine();
    }
}