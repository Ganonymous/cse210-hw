public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void Display()
    {
        foreach(Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach(string line in lines)
        {
            string[] parts = line.Split("|");
            
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._response = parts[2];

            _entries.Add(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outFile = new StreamWriter(fileName))
        {
            foreach(Entry entry in _entries)
            {
                outFile.WriteLine(entry.ToString());
            }
        }
    }
}