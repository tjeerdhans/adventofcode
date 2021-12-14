namespace aoc2021;

public class Day03 : Day
{
    public Day03() : base(3, 198, 230)
    {
    }

    private int[][] GetBitCounts(List<string> set)
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

        return bitCounts;
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var bitCounts = GetBitCounts(set.ToList());

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
        var bitCounts = GetBitCounts(set.ToList());
        
        var mostCommonBit = bitCounts[0][1] >= bitCounts[0][0] ? '1' : '0';
        var leastCommonBit = mostCommonBit == '0' ? '1' : '0';
        var ogrList = set.Where(s => s[0] == mostCommonBit).ToList(); // Oxygen Generator Rating
        var csrList = set.Where(s => s[0] == leastCommonBit).ToList(); // CO2 Scrubber Rating
        for (int i = 1; i < bitCounts.Length; i++)
        {
            var ogrBitCounts = GetBitCounts(ogrList);
            var csrBitCounts = GetBitCounts(csrList);
            mostCommonBit = ogrBitCounts[i][1] >= ogrBitCounts[i][0] ? '1' : '0';
            leastCommonBit = csrBitCounts[i][0] <= csrBitCounts[i][1] ? '0' : '1';
            if (ogrList.Count > 1)
            {
                ogrList = ogrList.Where(s => s[i] == mostCommonBit).ToList();
            }

            if (csrList.Count > 1)
            {
                csrList = csrList.Where(s => s[i] == leastCommonBit).ToList();
            }
        }

        var ogr = Convert.ToInt32(ogrList[0], 2);
        var csr = Convert.ToInt32(csrList[0], 2);
        return ogr * csr;
    }
}