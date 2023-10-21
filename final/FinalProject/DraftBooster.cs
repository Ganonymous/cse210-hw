
public class DraftBooster : Booster
{
    public DraftBooster(ReleaseSet set) : base(set)
    {
    }
    protected override List<string> ResolveFillPattern(ReleaseSet set)
    {
        bool hasFoil = CheckFoilInclude();
        bool bonus = set.HasBonus();
        bool doMythic = CheckRareUpgrade();
        List<string> pattern = new List<string>();
        for (int i = 0; i < 8; i++)
        {
            pattern.Add("common");
        }
        if (!hasFoil) pattern.Add("common");
        if (!bonus) pattern.Add("common");
        pattern.Add("uncommon");
        pattern.Add("uncommon");
        pattern.Add("uncommon");
        pattern.Add(doMythic ? "mythic" : "rare");
        if (hasFoil) pattern.Add("foil");
        if (bonus) pattern.Add("bonus");
        return pattern;
    }

    private bool CheckFoilInclude()
    {
        Random rnd = new Random();
        //Odds of a draft booster having a foil are 1 in 45
        return 1 == rnd.Next(1, 46);
    }

}