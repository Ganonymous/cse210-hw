public abstract class Booster
{
    protected List<Card> _cards = new List<Card>();
    public Booster(ReleaseSet set)
    {
        FillBooster(set, ResolveFillPattern(set));
    }
    public string GetDisplayString()
    {
        string output = "";
        foreach (Card card in _cards)
        {
            output += card.GetDisplayString() + "\n";
        }
        return output;
    }
    public string GetSaveString()
    {
        string output = "";
        foreach (Card card in _cards)
        {
            output += card.GetSaveString() + "\n";
        }
        return output;
    }
    public string GetBotString()
    {
        Console.WriteLine("Function not written: Booster.GetBotString()");
        return "";
    }
    public Card RemoveCard(string targetName)
    {
        Card target = _cards.Find(x => x.GetName() == targetName);
        if (target is not null)
        {
            _cards.Remove(target);
        }
        return target;
    }
    public int CardsRemaining()
    {
        return _cards.Count();
    }
    protected void FillBooster(ReleaseSet set, List<string> pattern)
    {
        foreach (string slot in pattern)
        {
            string find = slot;
            bool addFoil = slot.Last() == 'f';
            if (addFoil)
            {
                find = slot.Remove(slot.Length - 1);
            }
            switch (find)
            {
                case "common":
                case "uncommon":
                case "rare":
                case "mythic":
                    _cards.Add(set.PickMainCard(find));
                    break;
                case "bonus":
                    _cards.Add(set.PickBonusCard());
                    break;
                case "foil":
                    _cards.Add(set.PickFoil());
                    break;
            }
            if (addFoil)
            {
                _cards.Last().MakeFoil();
            }
        }
    }
    protected abstract List<string> ResolveFillPattern(ReleaseSet set);
    protected bool CheckRareUpgrade()
    {
        Random rnd = new Random();
        //Odds of a rare being replaced with a mythic are 1 in 7.4, or 10 in 74
        return 10 >= rnd.Next(1, 75);
    }
}