public class BreathingActivity: Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run(StatTracker tracker)
    {
        DisplayStartingMessage();
        Console.WriteLine();
        int remaining = _duration;
        while (remaining > 0)
        {
            if (remaining < 10)
            {
                BreathCycle(remaining);
                remaining = 0;
            } else
            {
                BreathCycle(10);
                remaining -= 10;
            }
        }
        DisplayEndingMessage();
        tracker.RecordBreathing(_duration);
    }

    private void BreathCycle(int length)
    {
        int inTime = (int)Math.Ceiling((double)length / 3);
        Console.WriteLine();
        Console.Write("Breathe in...");
        ShowCountDown(inTime);
        int outTime = Math.Max(1, length - inTime);
        Console.WriteLine();
        Console.Write("Now breathe out...");
        ShowCountDown(outTime);
        Console.WriteLine();
    }
}