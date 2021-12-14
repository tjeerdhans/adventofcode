namespace aoc2021;

public class Day08 : Day
{
    public Day08() : base(8, 26, 0)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var result = set
            .Select(s =>
                s.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[1])
            .SelectMany(s => s.Split(' '))
            .Count(s => s.Length is 2 or 3 or 4 or 7);
        return result;
    }

    protected override long GetSecondAnswer(string[] set)
    {
        return 0;
    }
}