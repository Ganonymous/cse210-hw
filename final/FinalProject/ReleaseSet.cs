public class ReleaseSet
{
    private string _name;
    private string _setCode;
    private List<Card> _mainCards = new List<Card>();
    private bool _hasBonus;
    private string _bonusName;
    private string _bonusCode;
    private List<Card> _bonusCards = new List<Card>();

    public ReleaseSet(string setFile)
    {
        string[] lines = File.ReadAllLines(setFile);

        string[] setData = lines[0].Split("|");
        _name = setData[0];
        _setCode = setData[1];
        if (setData.Length > 2)
        {
            _hasBonus = true;
            _bonusName = setData[2];
            _bonusCode = setData[3];
        }
        else
        {
            _hasBonus = false;
            _bonusName = "";
            _bonusCode = "";
        }

        int currentLine = 1;
        while (currentLine < lines.Length && lines[currentLine] != "Bonus:")
        {
            string[] parts = lines[currentLine].Split("|");
            _mainCards.Add(new Card(parts[0], parts[1], parts[2]));
            currentLine++;
        }
        if(currentLine < lines.Length)
        {
            currentLine++;
            while (currentLine < lines.Length)
            {
                string[] parts = lines[currentLine].Split("|");
                _bonusCards.Add(new Card(parts[0], parts[1], parts[2]));
                currentLine++;
            }
        }
    }

    public string GetShortDisplay()
    {
        if(_hasBonus)
        {
            return $"{_name} ({_setCode} & {_bonusCode})";
        }
        else
        {
            return $"{_name} ({_setCode})";
        }
    }
    public string GetLongDisplay()
    {
        string display = $"{_name} ({_setCode})";
        if(_hasBonus)
        {
            display += $"\n  and {_bonusName} ({_bonusCode})";
        }
        return display;
    }

    public Card PickMainCard(string rarity)
    {
        List<Card> candidates = new List<Card>();
        foreach (Card card in _mainCards)
        {
            if (card.GetRarity() == rarity)
            {
                candidates.Add(card);
            }
        }
        Random rnd = new Random();
        int index = rnd.Next(candidates.Count());
        return new Card(candidates[index]);
    }

    public Card PickBonusCard()
    {
        if (!_hasBonus)
        {
            return null;
        }
        else
        {
            Random rnd = new Random();
            int index = rnd.Next(_bonusCards.Count());
            return new Card(_bonusCards[index]);
        }
    }

    public Card PickFoil()
    {
        List<Card> candidates = _mainCards.Concat(_bonusCards).ToList();
        Random rnd = new Random();
        int index = rnd.Next(candidates.Count());
        return new Card(candidates[index], true);
    }

    public bool HasBonus()
    {
        return _hasBonus;
    }
}