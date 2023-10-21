public abstract class Drafter
{
    protected Booster _currentBooster;
    protected List<Card> _collectedCards;

    public Booster GetBooster()
    {
        return _currentBooster;
    }
    public void SetBooster(Booster newBooster)
    {
        _currentBooster = newBooster;
    }

    public abstract void PickCard();
}