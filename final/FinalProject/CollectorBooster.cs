public class CollectorBooster : Booster
{
    public CollectorBooster(ReleaseSet set) : base (set)
    {
    }

    protected override List<string> ResolveFillPattern(ReleaseSet set)
    {
        List<string> pattern = new List<string>();
        bool useBonus = set.HasBonus();
        pattern.Add(CheckRareUpgrade() ? "mythic" : "rare");
        pattern.Add(CheckRareUpgrade() ? "mythicf" : "raref");
        Random rnd = new Random();
        for (int i = 0; i < 9; i++)
        {
            pattern.Add(rnd.Next(10) < 7 ? "commonf" : "uncommonf");
        }
        pattern.Add("foil");
        pattern.Add("foil");
        pattern.Add("foil");
        pattern.Add(useBonus ? "bonus" : (CheckRareUpgrade() ? "mythic" : "rare"));
        return pattern;
    }
}