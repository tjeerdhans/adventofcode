namespace aoc2021;

public class Day06 : Day
{
    public Day06() : base(6, 5934, 26984457539)
    {
    }

    private readonly Dictionary<int, long> _newBornOffspringCountCache = new();

    private long GetFishCount(string[] set, int days)
    {
        var fish = set[0].Split(',').Select(n => Convert.ToInt32(n)).ToList();
        for (int day = 0; day < days; day++)
        {
            var newFish = 0;
            for (int i = 0; i < fish.Count; i++)
            {
                fish[i]--;
                if (fish[i] >= 0) continue;
                newFish++;
                fish[i] = 6;
            }

            if (newFish > 0)
            {
                fish.AddRange(Enumerable.Repeat(8, newFish));
            }
        }

        return fish.Count;
    }

    private long GetFishCountRecursive(string[] set, int days)
    {
        var fish = set[0].Split(',').Select(n => Convert.ToInt32(n)).ToList();
        long fishCount = fish.Count;
        for (int day = 1; day <= days; day++)
        {
            var newFish = 0;
            for (int i = 0; i < fish.Count; i++)
            {
                fish[i]--;
                if (fish[i] >= 0) continue;
                newFish++;
                fish[i] = 6;
            }

            if (newFish > 0)
            {
                fishCount += newFish * GetNewbornOffspringCount(days - day);
            }
        }

        return fishCount;
    }

    /// <summary>
    /// Get total number of offspring for a newborn lanternfish (internal timer=8) for the given number of days
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    private long GetNewbornOffspringCount(int days)
    {
        if (_newBornOffspringCountCache.ContainsKey(days))
        {
            return _newBornOffspringCountCache[days];
        }

        if (days < 8)
        {
            return 1;
        }

        var myOffspring = (days - 2) / 7;
        long myOffspringsOffspring = 0;
        for (var i = 1; i <= myOffspring; i++)
        {
            var delta = 2 + (i * 7);
            myOffspringsOffspring += GetNewbornOffspringCount(days - delta);
        }

        var result = 1 + myOffspringsOffspring;
        _newBornOffspringCountCache[days] = result;
        return result;
    }

    protected override long GetFirstAnswer(string[] set)
    {
        return GetFishCount(set, 80);
    }

    protected override long GetSecondAnswer(string[] set)
    {
        return GetFishCountRecursive(set, 256);
    }
}