using System;

class Program
{
    static void Main(string[] args)
    {
        List<ReleaseSet> availableSets = new List<ReleaseSet>();
        int userAction = 0;
        while (userAction != 6)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("  1. Add set");
            Console.WriteLine("  2. List sets");
            Console.WriteLine("  3. Open individual booster");
            Console.WriteLine("  4. Create & open sealed pool");
            Console.WriteLine("  5. Run a draft");
            Console.WriteLine("  6. Quit");
            Console.Write("Select an option: ");
            userAction = int.Parse(Console.ReadLine());
            switch (userAction)
            {
                case 1:
                    Console.WriteLine("What file is the set in?");
                    availableSets.Add(new ReleaseSet(Console.ReadLine()));
                    Console.WriteLine($"{availableSets.Last().GetShortDisplay()} added. Press Enter to continue");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("The current available sets are:");
                    foreach (ReleaseSet set in availableSets)
                    {
                        Console.WriteLine(set.GetLongDisplay());
                    }
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    break;
                case 3:
                    ReleaseSet boosterSet = ChooseSet(availableSets);
                    int boosterType = ChooseBoosterType();
                    Booster booster;
                    switch (boosterType)
                    {
                        case 1:
                            booster = new DraftBooster(boosterSet);
                            break;
                        case 2:
                            booster = new SetBooster(boosterSet);
                            break;
                        case 3:
                            booster = new CollectorBooster(boosterSet);
                            break;
                        default:
                            booster = null;
                            break;
                    }
                    Console.WriteLine("Your Booster:");
                    Console.WriteLine(booster.GetDisplayString());
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    break;
                case 4:
                    ReleaseSet sealedSet = ChooseSet(availableSets);
                    int sealedType = ChooseBoosterType();
                    if (0 < sealedType && sealedType < 4)
                    {
                        List<Booster> pool = new List<Booster>();
                        int totalCards = 0;
                        while (totalCards <= 75)
                        {
                            Booster sealedBooster = null;
                            switch (sealedType)
                            {
                                case 1:
                                    sealedBooster = new DraftBooster(sealedSet);
                                    break;
                                case 2:
                                    sealedBooster = new SetBooster(sealedSet);
                                    break;
                                case 3:
                                    sealedBooster = new CollectorBooster(sealedSet);
                                    break;
                            }
                            totalCards += sealedBooster.CardsRemaining();
                            pool.Add(sealedBooster);
                        }
                        Console.WriteLine("Your pool:");
                        foreach(Booster boost in pool)
                        {
                            Console.WriteLine(boost.GetDisplayString());
                        }
                        Console.WriteLine("Enter a file name to save this pool, or press enter to return to the menu");
                        string sealedFile = Console.ReadLine();
                        if(sealedFile != "")
                        {
                            using (StreamWriter outFile = new StreamWriter(sealedFile))
                            {
                                string boosterString = sealedType == 1 ? "draft" : "other";
                                if (boosterString == "other") boosterString = sealedType == 2 ? "set" : "collector";

                                outFile.WriteLine($"Sealed pool: {pool.Count}x {boosterString} boosters of {sealedSet.GetShortDisplay()}");
                                foreach (Booster next in pool)
                                {
                                    outFile.WriteLine(next.GetSaveString());
                                }
                            }
                        }
                    }
                    break;
                case 5:
                    ReleaseSet draftSet = ChooseSet(availableSets);
                    int draftType = ChooseBoosterType();
                    while (draftType < 1 || draftType > 3)
                    {
                        Console.WriteLine($"{draftType} is not a valid choice. Try again.");
                        draftType = ChooseBoosterType();
                    }
                    Console.Write("How many bots would you like to be in the draft? ");
                    int bots = int.Parse(Console.ReadLine());
                    DraftManager dm = new DraftManager(draftSet, draftType, bots);
                    dm.RunDraft();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
    }

    static ReleaseSet ChooseSet(List<ReleaseSet> sets)
    {
        Console.WriteLine("Current available sets: ");
        for (int i = 0; i < sets.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {sets[i].GetShortDisplay()}");
        }
        Console.Write("Which set will you open from? ");
        return sets[int.Parse(Console.ReadLine()) - 1];
    }
    static int ChooseBoosterType()
    {
        Console.WriteLine("There are 3 types of booster:");
        Console.WriteLine("  1. Draft Booster");
        Console.WriteLine("  2. Set Booster");
        Console.WriteLine("  3. Collector Booster");
        Console.Write("Which kind do you want to open? ");
        return int.Parse(Console.ReadLine());
    }
}