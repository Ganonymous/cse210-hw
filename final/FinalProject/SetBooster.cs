
public class SetBooster : Booster
{
    public SetBooster(ReleaseSet set) : base (set)
    {
    }
    protected override List<string> ResolveFillPattern(ReleaseSet set)
    {
        List<string> pattern = new List<string>();
        int connectedCommons = CountConnectedCommons();
        for (int i = 0; i < connectedCommons; i++)
        {
            pattern.Add("common");
        }
        for (int i = connectedCommons; i < 6; i++)
        {
            pattern.Add("uncommon");
        }
        pattern.Add(ChooseHeadTurner());
        pattern.Add(ChooseWildRarity());
        pattern.Add(ChooseWildRarity());
        pattern.Add(CheckRareUpgrade() ? "mythic" : "rare");
        pattern.Add("foil");
        return pattern;
    }

    private int CountConnectedCommons()
    {
        Random rnd = new Random();
        int result = rnd.Next(1000); //odds are given to .1%, so out of a thousand
        if (result < 20) //2%
        {
            return 0;
        }
        else if (result < 55) //3.5%, for 5.5% total
        {
            return 1;
        }
        else if (result < 125) //7%, for 12.5% total
        {
            return 2;
        }
        else if (result < 250) //12.5%, for 25% total
        {
            return 3;
        }
        else if (result < 650) //40%, for 65% total
        {
            return 4;
        }
        else //remaining 35%
        {
            return 5;
        }
    }
    private string ChooseHeadTurner()
    {
        Random rnd = new Random();
        if (rnd.Next(10) < 7) //70% chance
        {
            return "commonf";
        }
        else
        {
            return "uncommonf";
        }
    }
    private string ChooseWildRarity()
    {
        Random rnd = new Random();
        //calculated wild odds: Common 70%, Uncommon 17.5%, Rare/Mythic 12.5%
        int result = rnd.Next(1000);
        if (result < 125)
        {
            return CheckRareUpgrade() ? "mythic" : "rare";
        }
        else if (result < 300)
        {
            return "uncommon";
        }
        else
        {
            return "common";
        }
    }
}
