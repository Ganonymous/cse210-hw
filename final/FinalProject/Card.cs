public class Card
{
    private string _name;
    private string _color;
    private string _rarity;
    private bool _isFoil;

    public Card(string name, string color, string rarity)
    {
        _name = name;
        _color = color;
        _rarity = rarity;
        _isFoil = false;
    }
    public Card(Card original, bool foil = false)
    {
        _name = original.GetName();
        _color = original.GetColor();
        _rarity = original.GetRarity();
        _isFoil = foil;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetColor()
    {
        return _color;
    }
    public string GetRarity()
    {
        return _rarity;
    }
    public string GetDisplayString()
    {
        string foilString = _isFoil ? ", *foil*" : "";
        return $"{_name}: {_color} {_rarity}{foilString}";
    }
    public string GetSaveString()
    {
        return $"{_name}|{_color}|{_rarity}|{_isFoil}";
    }
    public bool IsMulticolor()
    {
        return _color.Contains('/');
    }
    public void MakeFoil()
    {
        _isFoil = true;
    }
}