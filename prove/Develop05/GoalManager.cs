public class GoalManager
{
    private string _userName;
    private string _className;
    private int _totalExp;
    private int _currentLevel;
    private int _levelExp;
    private int _baseLevelExp;
    private double _levelExpGrowthFactor;
    private List<Goal> _goals = new List<Goal>();

    public GoalManager()
    {
        _userName = "Anonymous";
        _className = "Person";
        _totalExp = 0;
        _currentLevel = 1;
        _levelExp = 0;
        _baseLevelExp = 100;
        _levelExpGrowthFactor = 1.2;
    }

    public void UpdateName()
    {
        Console.Write("What is your name? ");
        _userName = Console.ReadLine();
    }
    public void UpdateClass()
    {
        Console.Write($"Your class is currently {_className}. What would you like it to be? ");
        _className = Console.ReadLine();
    }
    public void UpdateProgression()
    {
        Console.WriteLine($"Currently, it takes {_baseLevelExp} exp for your first level, then {_levelExpGrowthFactor} times as much for each successive level.");
        Console.Write("How much exp do you want the first level to take? ");
        _baseLevelExp = int.Parse(Console.ReadLine());
        Console.Write("And how any times more should each level cost? ");
        _levelExpGrowthFactor = double.Parse(Console.ReadLine());
        _currentLevel = 1;
        _levelExp = _totalExp;
        while (CheckLevelUp());
        Console.WriteLine($"With these progression settings, you are now level {_currentLevel}.");
    }
    private int GetExpToNext(){
        double levelsMult = Math.Pow(_levelExpGrowthFactor, _currentLevel - 1);
        double asFloat = _baseLevelExp * levelsMult;
        return (int)Math.Round(asFloat);
    }
    private bool CheckLevelUp()
    {
        int target = GetExpToNext();
        if (_levelExp < target)
        {
            return false;
        }
        else
        {
            _currentLevel++;
            _levelExp -= target;
            return true;
        }
    }

    public void DisplayPlayerInfo()
    {
        int target = GetExpToNext();
        Console.WriteLine($"{_userName}: Level {_currentLevel} {_className}");
        Console.WriteLine($"Total Exp: {_totalExp}; To Next Level: {_levelExp}/{target}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for(int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}: ");
            _goals[i].Display();
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        int response = int.Parse(Console.ReadLine());
        switch(response)
        {
            case 1:
                Console.Write("What is the name of your goal? ");
                string sName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string sDesc = Console.ReadLine();
                Console.Write("What amount of exp it is worth? ");
                int sValue = int.Parse(Console.ReadLine());
                _goals.Add(new SimpleGoal(sName, sDesc, sValue));
                break;
            case 2:
                Console.Write("What is the name of your goal? ");
                string eName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string eDesc = Console.ReadLine();
                Console.Write("What amount of exp it is worth? ");
                int eValue = int.Parse(Console.ReadLine());
                _goals.Add(new EternalGoal(eName, eDesc, eValue));
                break;
            case 3:
            Console.Write("What is the name of your goal? ");
                string cName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string cDesc = Console.ReadLine();
                Console.Write("What amount of exp it is worth? ");
                int cValue = int.Parse(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished to earn a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(cName, cDesc, cValue, target, bonus));
                break;
            default:
                Console.WriteLine($"Your input '{response}' does not match an option. Returning to menu.");
                break;
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for(int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_goals[i].GetName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int targetIndex = int.Parse(Console.ReadLine()) - 1;
        if (targetIndex >= 0 && targetIndex < _goals.Count)
        {
            int earned = _goals[targetIndex].RecordEvent();
            _totalExp += earned;
            _levelExp += earned;
            if (CheckLevelUp())
            {
                Console.WriteLine($"Congratulations! You leveled up! You are now level {_currentLevel}");
            }
        }
        else
        {
            Console.WriteLine("That is not the number of a goal. Returning to menu");
        }
    }
    public void SaveToFile()
    {
        Console.Write("What is the name of the goal file? ");
        string fileName = Console.ReadLine();
        using (StreamWriter outFile = new StreamWriter(fileName))
        {
            outFile.WriteLine($"{_userName}|{_className}|{_totalExp}|{_baseLevelExp}|{_levelExpGrowthFactor}");
            foreach(Goal goal in _goals)
            {
                outFile.WriteLine(goal.GetSaveString());
            }
        }
    }
    public void LoadFromFile()
    {
        Console.Write("What is the name of the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = File.ReadAllLines(fileName);
        string[] userData = lines[0].Split("|");
        _userName = userData[0];
        _className = userData[1];
        _totalExp = int.Parse(userData[2]);
        _levelExp = _totalExp;
        _baseLevelExp = int.Parse(userData[3]);
        _levelExpGrowthFactor = double.Parse(userData[4]);
        while (CheckLevelUp());

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            switch (parts[0])
            {
                case "SimpleGoal":
                    bool isComplete = parts[4] == "1";
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), isComplete));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;
            }
        }
    }
}