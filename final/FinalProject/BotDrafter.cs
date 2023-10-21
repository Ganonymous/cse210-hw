public class BotDrafter : Drafter
{
    private string _mainColor;
    private string _secondaryColor;
    private int _colorCommitment;
    private int _swapToSecondaryOdds;

    public override void PickCard()
    {
        Card selection = _currentBooster.RemoveCard(EvaluateBooster());
        _collectedCards.Add(selection);
        UpdateColors(selection);
    }

    private string EvaluateBooster()
    {
        Console.WriteLine("Function not created: BotDrafter.EvaluateBooster");
        return "";
    }
    private void UpdateColors(Card picked)
    {
        Console.WriteLine("Function not created: BotDrafter.UpdateColors()");
    }
}