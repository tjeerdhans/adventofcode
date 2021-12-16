using Accord.Math;

namespace aoc2021;

public class Day09 : Day
{
    public Day09() : base(9, 15, 0)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var heightMap = set.Select(s => s.Select(i => int.Parse(i.ToString())).ToArray()).ToArray();
        
        var riskLevelSum = 0;
        for (int x = 0; x < heightMap.Length; x++)
        {
            for (int y = 0; y < heightMap[x].Length; y++)
            {
                var h = heightMap[x][y];
                if (x == 0)
                {
                    if (y == 0) // top left corner
                    {
                        if (heightMap[1][0] > h && heightMap[0][1] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                    else if (y == heightMap[x].Length - 1) // top right corner
                    {
                        if (heightMap[1][y] > h && heightMap[0][y - 1] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                    else // top edge
                    {
                        if (heightMap[0][y - 1] > h && heightMap[1][y] > h && heightMap[0][y + 1] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                }
                else if (x == heightMap.Length - 1)
                {
                    if (y == 0) // bottom left corner
                    {
                        if (heightMap[x - 1][0] > h && heightMap[x][1] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                    else if (y == heightMap[x].Length - 1) // bottom right corner
                    {
                        if (heightMap[x][y - 1] > h && heightMap[x - 1][y] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                    else // bottom edge
                    {
                        if (heightMap[x][y - 1] > h && heightMap[x - 1][y] > h && heightMap[x][y + 1] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                }
                else
                {
                    if (y == 0) // left edge
                    {
                        if (heightMap[x - 1][y] > h && heightMap[x][y + 1] > h && heightMap[x + 1][y] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                    else if (y == heightMap[x].Length - 1) // right edge
                    {
                        if (heightMap[x - 1][y] > h && heightMap[x][y - 1] > h && heightMap[x + 1][y] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                    else // the rest
                    {
                        if (heightMap[x][y - 1] > h && heightMap[x - 1][y] > h && heightMap[x][y + 1] > h &&
                            heightMap[x + 1][y] > h)
                        {
                            riskLevelSum += h + 1;
                        }
                    }
                }
            }
        }

        return riskLevelSum;
    }

    protected override long GetSecondAnswer(string[] set)
    {
        return 0;
    }
}