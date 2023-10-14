public class ChecklistGoal: Goal
{
    private int _timesDone;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int exp, int target, int bonus, int times = 0): base(name, desc, exp)
    {
        _target = target;
        _bonus = bonus;
        _timesDone = times;
    }
    public override bool IsComplete()
    {
        return _timesDone >= _target;
    }
    public override void Display()
    {
        char completion = IsComplete() ? 'X' : ' ';
        Console.WriteLine($"[{completion}] {_name} ({_description}) -- Current Progress: {_timesDone}/{_target}");
    }
    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal is already complete. Choose another.");
            return 0;
        }
        else
        {
            _timesDone++;
            Console.WriteLine($"Good work! You earned {_exp} exp!");
            if (IsComplete())
            {
                Console.WriteLine($"Excellent job! You completed the goal and earned {_bonus} bonus exp!");
                return _exp + _bonus;
            }
            else
            {
                return _exp;
            }
        }
        
    }
    public override string GetSaveString()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_exp}|{_target}|{_bonus}|{_timesDone}";
    }
}