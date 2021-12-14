namespace aoc2021;

public class Day02 : Day
{
    public Day02() : base(2, 150, 900)
    {
    }
    
    /// <summary>
    /// Get position.
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    protected override long GetFirstAnswer(string[] set)
    {
        var hor = 0;
        var depth = 0;
        foreach (var c in set)
        {
            if (c.StartsWith("forward"))
            {
                hor += int.Parse(c[8..]);
            }
            else if (c.StartsWith("down"))
            {
                depth += int.Parse(c[5..]);
            }
            else
            {
                depth -= int.Parse(c[3..]);
            }
        }

        return hor * depth;
    }

    /// <summary>
    /// Get position using aim.
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    protected override long GetSecondAnswer(string[] set)
    {
        var hor = 0;
        var aim = 0;
        var depth = 0;
        foreach (var c in set)
        {
            if (c.StartsWith("forward"))
            {
                var delta = int.Parse(c[8..]);
                hor += delta;
                depth += aim * delta;
            }
            else if (c.StartsWith("down"))
            {
                aim += int.Parse(c[5..]);
            }
            else
            {
                aim -= int.Parse(c[3..]);
            }
        }

        return hor * depth;
    }
}