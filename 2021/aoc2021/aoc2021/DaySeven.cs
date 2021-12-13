using Accord.Math;
using Accord.Statistics;

namespace aoc2021;

public class DaySeven : Day
{
    public DaySeven() : base(7, 37, 168)
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
        var positions = set[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        var average = Convert.ToInt32(Math.Round(positions.Average()));
        
        return positions.Sum(n =>
        {
            var distance = Math.Abs(n - average);
            return ((distance * distance) + distance) / 2;
        });
    }
}