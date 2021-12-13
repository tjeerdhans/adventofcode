using Accord.Statistics;

namespace aoc2021;

public class DaySeven : Day
{
    public DaySeven() : base(7, 37, 0)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var positions = set[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        var median = Convert.ToInt32(Math.Round(positions.Median()));
        Console.WriteLine($"median: {median}");
        return positions.Sum(n => Math.Abs(n - median));
    }

    protected override long GetSecondAnswer(string[] set)
    {
        return 0;
    }
}