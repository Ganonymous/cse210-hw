public class DraftManager
{
    private List<Drafter> _drafters;
    private List<Booster> _boosters;
    private string _boosterType;
    private string _setName;

    public DraftManager(ReleaseSet set, int boosterType, int bots)
    {
        _drafters = new List<Drafter>();
        _boosters = new List<Booster>();
        switch (boosterType)
        {
            case 1: 
                _boosterType = "draft";
                break;
            case 2:
                _boosterType = "set";
                break;
            case 3:
                _boosterType = "collector";
                break;

        }
        _setName = set.GetShortDisplay();
        _drafters.Add(new UserDrafter());
        for (int i = 0; i < bots; i++)
        {
            _drafters.Add(new BotDrafter());
        }
        for(int i = 0; i < _drafters.Count; i++)
        {
            int addedCards = 0;
            while (addedCards < 40)
            {
                Booster next = null;
                switch (boosterType)
                {
                    case 1:
                        next = new DraftBooster(set);
                        break;
                    case 2:
                        next = new SetBooster(set);
                        break;
                    case 3:
                        next = new CollectorBooster(set);
                        break;
                }
                addedCards += next.CardsRemaining();
                _boosters.Add(next);
            }
        }
    }

    public void RunDraft()
    {
        Console.WriteLine($"Beginning draft of {_setName} {_boosterType} boosters.");
        int currentRound = 1;
        while (_boosters.Count > 0)
        {
            Console.WriteLine($"Round {currentRound}");
            DraftRound(currentRound % 2 == 0);
            currentRound++;
        }
        UserDrafter user = (UserDrafter)_drafters[0];
        user.DisplayPool();
        Console.WriteLine("Enter a file name to save this pool, or press enter to return to the menu.");
        string fileName = Console.ReadLine();
        if(fileName != "")
        {
            user.SavePool(fileName);
        }
    }   
    private void DraftRound(bool passReverse)
    {
        foreach (Drafter drafter in _drafters)
        {
            Booster next = _boosters[0];
            _boosters.Remove(next);
            drafter.SetBooster(next);
        }
        while (_drafters[0].GetBooster().CardsRemaining() > 0)
        {
           foreach (Drafter drafter in _drafters)
           {
            drafter.PickCard();
           }
           PassBoosters(passReverse);
        }
    }
    private void PassBoosters(bool reverse)
    {
        Booster setAside;
        if(reverse)
        {
            setAside = _drafters[0].GetBooster();
            for (int i = 0; i < _drafters.Count - 1; i++)
            {
                _drafters[i].SetBooster(_drafters[i + 1].GetBooster());
            }
            _drafters.Last().SetBooster(setAside);
        }
        else
        {
            setAside = _drafters.Last().GetBooster();
            for(int i = _drafters.Count - 1; i > 0; i--)
            {
                _drafters[i].SetBooster(_drafters[i - 1].GetBooster());
            }
            _drafters[0].SetBooster(setAside);
        }
    }
}