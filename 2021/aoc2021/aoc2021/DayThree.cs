namespace aoc2021;

public class DayThree : Day
{
    public DayThree() : base(3, 198, 0)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var diagnostics = set.Select(l => Convert.ToInt32(l, 2)).ToArray();
        var gammaRate = diagnostics[0];
        var epsilonRate = diagnostics[0];

        foreach (var diagnostic in diagnostics.Skip(1))
        {
            gammaRate &= diagnostic;
            epsilonRate |= diagnostic;
        }

        return gammaRate * epsilonRate;
    }

    protected override long GetSecondAnswer(string[] set)
    {
        return 0;
    }
}