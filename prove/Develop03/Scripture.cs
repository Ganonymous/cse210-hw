public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int totalHide = Math.Min(numberToHide + ShowAll(), _words.Count); // If fewer than numberToHide aren't hidden, hide all
        Random random = new Random();
        for (int i = 0; i < totalHide; i++)
        {
            bool success = false;
            do{
                int index = random.Next(0, _words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    success = true;
                }
            }while(!success);
        }
    }

    private int ShowAll()
    {
        int numberShown = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                word.Show();
                numberShown++;
            }
        }
        return numberShown;
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        bool allHidden = true;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                allHidden = false;
            }
        }
        return allHidden;
    }
}