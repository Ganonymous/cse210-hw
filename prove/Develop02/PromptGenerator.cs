using System.Security.Cryptography;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count());
        return _prompts[index];
    }

    public void Display()
    {
        Console.WriteLine("Current prompts:");
        foreach(string prompt in _prompts)
        {
            Console.WriteLine(prompt);
        }
    }

    public void LoadFromFile(string fileName)
    {
        _prompts.Clear();

        string[] lines = File.ReadAllLines(fileName);
        foreach(string line in lines)
        {
            _prompts.Add(line);
        }

    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outFile = new StreamWriter(fileName))
        {
            foreach(string prompt in _prompts)
            {
                outFile.WriteLine(prompt);
            }
        }

    }
}