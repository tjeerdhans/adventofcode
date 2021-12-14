using Accord.Math;
using Accord.Statistics;

namespace aoc2021;

public class Day07 : Day
{
    public Day07() : base(7, 37, 168)
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
        var mean = Convert.ToInt32(positions.Mean());

        var result = Enumerable.Range(mean - 5, 10).Min(m => positions.Sum(n =>
        {
            var d = Convert.ToInt32(Math.Abs(n - m));
            return (d * d + d) / 2;
        }));

        return result;
    }
}