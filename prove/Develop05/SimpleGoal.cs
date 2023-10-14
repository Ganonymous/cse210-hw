public class SimpleGoal: Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string desc, int exp, bool done = false): base(name, desc, exp)
    {
        _isComplete = done;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override void Display()
    {
        char completion = _isComplete ? 'X' : ' ';
        Console.WriteLine($"[{completion}] {_name} ({_description})");
    }
    public override int RecordEvent()
    {
        if(_isComplete)
        {
            Console.WriteLine("This goal is already complete. Choose another.");
            return 0;
        }
        else
        {
            _isComplete = true;
            Console.WriteLine($"Well done! You earned {_exp} exp!");
            return _exp;
        }
    }
    public override string GetSaveString()
    {
        char completion = _isComplete ? '1' : '0';
        return $"SimpleGoal|{_name}|{_description}|{_exp}|{completion}";
    }
}