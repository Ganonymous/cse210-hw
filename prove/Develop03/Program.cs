using System;

class Program
{
    static List<Scripture> scriptures = new List<Scripture>();
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer");
        Console.WriteLine("Enter the name of a file to load scriptures from, or 'default' for the default list.");
        string response = Console.ReadLine();
        if (response.ToLower() == "default")
        {
            LoadDefaultScriptures();
        } else
        {
            LoadFromFile(response);
        }
        Console.WriteLine("Scriptures loaded. Press Enter to continue");
        Console.ReadLine();
        Console.Clear();

        Random rnd = new Random();
        while (scriptures.Count > 0)
        {
            int index = rnd.Next(0, scriptures.Count);
            Scripture activeScripture = scriptures[index];
            scriptures.Remove(activeScripture);
            while (!activeScripture.IsCompletelyHidden())
            {
                Console.WriteLine(activeScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press enter to continue, type 'next' for another scripture, or type 'quit' to finish:");
                response = Console.ReadLine();
                Console.Clear();
                if (response == "next")
                {
                    break;
                } else if (response == "quit")
                {
                    return;
                }
                activeScripture.HideRandomWords(3);
            }
            if(activeScripture.IsCompletelyHidden())
            {
                Console.WriteLine(activeScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press enter to continue, or type 'quit to finish:");
                response = Console.ReadLine();
                Console.Clear();
                if (response == "quit")
                {
                    return;
                }
            }
        }

    }

    static void LoadFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line .Split("|");
            if (parts.Count() == 4)
            {
                scriptures.Add(new Scripture(new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2])), parts[3]));
            } else{
                scriptures.Add(new Scripture(new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])), parts[4]));
            }
        }

    }
    static void LoadDefaultScriptures()
    {
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths"));
        scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life"));
    }
}