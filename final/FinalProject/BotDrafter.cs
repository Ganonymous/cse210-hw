public class BotDrafter : Drafter
{
    private string _mainColor;
    private string _secondaryColor;
    private int _colorCommitment;
    private int _swapToSecondaryOdds;

    public BotDrafter() : base()
    {
        _mainColor = "none";
        _secondaryColor = "none";
        _colorCommitment = 0;
        _swapToSecondaryOdds = 50;
    }
    public override void PickCard()
    {
        Card selection = null;
        while (selection is null)
        {
            selection = _currentBooster.RemoveCard(EvaluateBooster());
        }
        _collectedCards.Add(selection);
        UpdateColors(selection);
    }

    private string EvaluateBooster()
    {
        string[] lines = _currentBooster.GetBotString().Split("||");
        List<string[]> options = new List<string[]>();
        foreach (string line in lines)
        {
            options.Add(line.Split('|'));
        }
        List<int> weighted = new List<int>();
        Random rnd = new Random();
        for (int i = 0; i < options.Count - 1; i++)
        {
            if(options[i][2] == "rare")
            {
                weighted.Add(i);
            }
            if(options[i][2] == "mythic")
            {
                weighted.Add(i);
                weighted.Add(i);
            }
            if(options[i][1].Contains(_mainColor))
            {
                weighted.Add(i);
                weighted.Add(i);
            }
            if(options[i][1].Contains(_secondaryColor))
            {
                weighted.Add(i);
            }
            if(_mainColor == "none" && rnd.Next() % 2 == 0)
            {
                weighted.Add(i);
            }
            if(_secondaryColor == "none" && rnd.Next() % 3 == 0)
            {
                weighted.Add(i);
            }
            if (rnd.Next() % 10 == 0)
            {
                weighted.Add(i);
            }
        }
        int index = rnd.Next(weighted.Count);
        int optionIndex = weighted.Count > 0 ? weighted[index] : rnd.Next(options.Count);
        string choice = options[optionIndex][0];
        return choice;
    }
    private void UpdateColors(Card picked)
    {
        Random rnd = new Random();

        if(picked.IsMulticolor())
        {
            string[] colors = picked.GetColor().Split('/');
            if(colors.Contains(_mainColor) && colors.Contains(_secondaryColor))
            {
                _colorCommitment++;
            }
            else if (colors.Contains(_mainColor))
            {
                _colorCommitment--;
                if (_colorCommitment < 0 && rnd.Next() % 2 == 0)
                {
                    _secondaryColor = colors[0] == _mainColor ? colors[1] : colors[0];
                }
                else
                {
                    _swapToSecondaryOdds -= 5;
                }
            }
            else if (colors.Contains(_secondaryColor))
            {
                _swapToSecondaryOdds += 5;
            }
            else if (_mainColor == "none")
            {
                _mainColor = colors[0];
                _secondaryColor = colors[1];
                _colorCommitment++;
            }
            else if (_secondaryColor == "none")
            {
                _secondaryColor = colors[0];
                _swapToSecondaryOdds += 5;
            }
            else
            {
                _colorCommitment--;
                if(_colorCommitment < 0 && rnd.Next() % 2 == 0)
                {
                    _secondaryColor = colors[0];
                    _colorCommitment = 0;
                }
            }
        }
        else
        {
            if (picked.GetColor() != "colorless")
            {
                string color = picked.GetColor();
                if (_mainColor == "none" || color == _mainColor)
                {
                    _mainColor = color;
                    _swapToSecondaryOdds -= 5;
                }
                else if (_secondaryColor == "none" || color == _secondaryColor)
                {
                    _secondaryColor = color;
                    _colorCommitment++;
                    _swapToSecondaryOdds += 5;
                }
                else
                {
                    _colorCommitment--;
                    if(_colorCommitment < 0 && rnd.Next() % 2 == 0)
                    {
                        _secondaryColor = color;
                        _colorCommitment = 0;
                    }
                }
            }
        }

        if(rnd.Next(100) > _swapToSecondaryOdds && _secondaryColor != "none")
        {
            string oldMain = _mainColor;
            _mainColor = _secondaryColor;
            _secondaryColor = oldMain;
            _swapToSecondaryOdds = 100 - _swapToSecondaryOdds;
        }
    }
}