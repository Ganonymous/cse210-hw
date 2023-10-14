public abstract class Goal {
    protected string _name;
    protected string _description;
    protected int _exp;

    public Goal(string name, string description, int exp)
    {
        _name = name;
        _description = description;
        _exp = exp;
    }

    public string GetName()
    {
        return _name;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract void Display();
    public abstract string GetSaveString();
}