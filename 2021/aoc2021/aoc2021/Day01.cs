namespace aoc2021;

/// <summary>
/// Day 1: Sonar sweep
/// </summary>
public class Day01 : Day
{
    public Day01(): base(1, 7,5)
    {
      }

    /// <summary>
    /// Get the times the depth increases between sonar readings.
    /// </summary>
    /// <returns></returns>
    protected override long GetFirstAnswer(string[] set)
    {
        var depths = set.Select(i => Convert.ToInt32(i)).ToArray();
        var count = 0;
        var current = depths[0];
        foreach (var depth in depths.Skip(1))
        {
            if (depth > current)
            {
                count++;
            }

            current = depth;
        }

        return count;
    }

    /// <summary>
    /// Get the times the depth increases between sonar readings using a 3-value window.
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    protected override long GetSecondAnswer(string[] set)
    {
        var depths = set.Select(i => Convert.ToInt32(i)).ToArray();
        var count = 0;
        var currentWindow = depths[0] + depths[1] + depths[2];
        for (var i = 1; i < depths.Length-2; i++)
        {
            var window = depths[i] + depths[i + 1] + depths[i + 2];
            if (window > currentWindow)
            {
                count++;
            }

            currentWindow = window;
        }

        return count;
    }

}