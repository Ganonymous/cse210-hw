public class StatTracker
{
    private int _breathingDuration = 0;
    private int _breathingSessions = 0;
    private int _listingDuration = 0;
    private int _listingCount = 0;
    private int _listingSessions = 0;
    private int _reflectingDuration = 0;
    private int _reflectingSessions = 0;

    public void DisplayStats()
    {
        Console.Clear();
        Console.WriteLine($"You have completed {_breathingSessions} sessions of the Breathing Activity, for a total of {_breathingDuration} seconds.");
        Console.WriteLine($"You have completed {_listingSessions} sessions of the Listing Activity, recording {_listingCount} items in {_listingDuration} seconds.");
        Console.WriteLine($"You have completed {_reflectingSessions} sessions of the Reflecting Activity, for a total of {_reflectingDuration} seconds.");
        Console.WriteLine("Press 'enter' to return to the menu.");
        Console.ReadLine();
        Console.Clear();
    }

    public void RecordBreathing(int duration)
    {
        _breathingDuration += duration;
        _breathingSessions++;
    }

    public void RecordListing(int duration, int count)
    {
        _listingDuration += duration;
        _listingCount += count;
        _listingSessions++;
    }

    public void RecordReflecting(int duration)
    {
        _reflectingDuration += duration;
        _reflectingSessions++;
    }
}