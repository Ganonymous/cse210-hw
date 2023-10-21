public class UserDrafter : Drafter
{
    public override void PickCard()
    {
        Console.WriteLine("Function not created: UserDrafter.PickCard");
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