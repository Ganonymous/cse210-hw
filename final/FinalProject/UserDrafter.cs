public class UserDrafter : Drafter
{
    public override void PickCard()
    {
        Console.Clear();
        bool cardPicked = false;
        while (!cardPicked)
        {
            Console.WriteLine();
            Console.WriteLine("Your booster contains:");
            Console.WriteLine(_currentBooster.GetDisplayString());
            Console.WriteLine("Enter the name of the card you want to pick, or press enter to review your pool.");
            string response = Console.ReadLine();
            if(response == "")
            {
                DisplayPool();
            }
            else
            {
                Card picked = _currentBooster.RemoveCard(response);
                if(picked is not null)
                {
                    _collectedCards.Add(picked);
                    cardPicked = true;
                }
                else
                {
                    Console.WriteLine($"'{response}' is not the name of a card in the booster. Try again.");
                }
            }
        }
    }
    public void DisplayPool()
    {
        Console.WriteLine("Your Cards:");
        foreach (Card card in _collectedCards)
        {
            Console.WriteLine(card.GetDisplayString());
        }
    }
    public void SavePool(string fileName)
    {
        using (StreamWriter outFile = new StreamWriter(fileName))
        {
            outFile.WriteLine("Draft pool:");
            foreach (Card card in _collectedCards)
            {
                outFile.WriteLine(card.GetSaveString());
            }
        }
    }
}