namespace aoc2021;

public class DayThree : Day
{
    public DayThree() : base(3, 198, 230)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var bitCounts = new int[set[0].Length][];
        for (int i = 0; i < set[0].Length; i++)
        {
            bitCounts[i] = new[] { 0, 0 };
        }

        foreach (var s in set)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    bitCounts[i][0]++;
                }
                else
                {
                    bitCounts[i][1]++;
                }
            }
        }

        var gammaRateString = new string(bitCounts.Select(c => c[0] > c[1] ? '0' : '1').ToArray());
        var gammaRate = Convert.ToInt32(gammaRateString, 2);
        var epsilonRateString = new string(bitCounts.Select(c => c[0] > c[1] ? '1' : '0').ToArray());
        var epsilonRate = Convert.ToInt32(epsilonRateString, 2);

        return gammaRate * epsilonRate;
    }

    /// <summary>
    /// Next, you should verify the life support rating, which can be determined by multiplying the
    /// oxygen generator rating by the CO2 scrubber rating.
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    protected override long GetSecondAnswer(string[] set)
    {
        return 0;
    }
}