public class EternalGoal: Goal
{
    private int _timesDone;

    public EternalGoal(string name, string desc, int exp, int times = 0): base(name, desc, exp)
    {
        _timesDone = times;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override void Display()
    {
        Console.WriteLine($"[ ] {_name} ({_description}) -- Done {_timesDone} times");
    }
    public override int RecordEvent()
    {
        _timesDone++;
        Console.WriteLine($"Good work! You earned {_exp} exp!");
        return _exp;
    }
    public override string GetSaveString()
    {
        return $"EternalGoal|{_name}|{_description}|{_exp}|{_timesDone}";
    }
}