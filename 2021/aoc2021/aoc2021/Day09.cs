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

        var lowPoints = GetLowPoints(heightMap);
        var riskLevelSum = lowPoints.Sum(p => heightMap[p.x][p.y] + 1);

        return riskLevelSum;
    }

    protected override long GetSecondAnswer(string[] set)
    {
        var heightMap = set.Select(s => s.Select(i => int.Parse(i.ToString())).ToArray()).ToArray();

        var lowPoints = GetLowPoints(heightMap);
        var basinSizes = new List<int>();
        foreach (var p in lowPoints)
        {
            basinSizes.Add(GetBasinSize(heightMap, p));
        }

        basinSizes.Sort();
        return basinSizes.TakeLast(3).Aggregate((result, next) => result * next);
    }

    private static int GetBasinSize(int[][] heightMap, (int x, int y) lowPoint)
    {
        var result = 1;
        for (int x = lowPoint.x; x < heightMap.Length; x++)
        {
            if (heightMap[x][lowPoint.y] < 9)
            {
                result++;
            }
        }

        return result;
    }

    private static IEnumerable<(int x, int y)> GetLowPoints(int[][] heightMap)
    {
        var result = new List<(int x, int y)>();
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
                            result.Add((x, y));
                        }
                    }
                    else if (y == heightMap[x].Length - 1) // top right corner
                    {
                        if (heightMap[1][y] > h && heightMap[0][y - 1] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                    else // top edge
                    {
                        if (heightMap[0][y - 1] > h && heightMap[1][y] > h && heightMap[0][y + 1] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                }
                else if (x == heightMap.Length - 1)
                {
                    if (y == 0) // bottom left corner
                    {
                        if (heightMap[x - 1][0] > h && heightMap[x][1] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                    else if (y == heightMap[x].Length - 1) // bottom right corner
                    {
                        if (heightMap[x][y - 1] > h && heightMap[x - 1][y] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                    else // bottom edge
                    {
                        if (heightMap[x][y - 1] > h && heightMap[x - 1][y] > h && heightMap[x][y + 1] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                }
                else
                {
                    if (y == 0) // left edge
                    {
                        if (heightMap[x - 1][y] > h && heightMap[x][y + 1] > h && heightMap[x + 1][y] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                    else if (y == heightMap[x].Length - 1) // right edge
                    {
                        if (heightMap[x - 1][y] > h && heightMap[x][y - 1] > h && heightMap[x + 1][y] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                    else // the rest
                    {
                        if (heightMap[x][y - 1] > h && heightMap[x - 1][y] > h && heightMap[x][y + 1] > h &&
                            heightMap[x + 1][y] > h)
                        {
                            result.Add((x, y));
                        }
                    }
                }
            }
        }

        return result;
    }
}