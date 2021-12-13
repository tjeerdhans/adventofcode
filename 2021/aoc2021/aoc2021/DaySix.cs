namespace aoc2021;

public class DaySix : Day
{
    public DaySix() : base(6, 5934, 26984457539)
    {
    }

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

            fish.AddRange(Enumerable.Repeat(8, newFish));
            if (newFish > 0)
            {
                Console.Write($"{day}:{fish.Count} ");
            }
        }

        return fish.Count;
    }

    protected override long GetFirstAnswer(string[] set)
    {
        return GetFishCount(set, 64);
    }

    protected override long GetSecondAnswer(string[] set)
    {
        return GetFishCount(set, 128);
    }
}