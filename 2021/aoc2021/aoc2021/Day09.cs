using Accord.Math;

namespace aoc2021;

public class Day09 : Day
{
    public Day09() : base(9, 15, 1134)
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
        var heightMatrix = heightMap.ToMatrix();
        //heightMatrix.Apply(i => i != 9 ? 0 : 9);

        var lowPoints = GetLowPoints(heightMap);
        var basinSizes = new List<int>();
        foreach (var p in lowPoints)
        {
            basinSizes.Add(GetBasinSize(heightMatrix, p));
        }

        basinSizes.Sort();
        var nineCount = heightMap.Sum(x => x.Count(y => y == 9));
        var basinSum = basinSizes.Sum();
        Console.WriteLine($"Basin sum + all nines should amount to all of the nodes ({heightMatrix.Length}): {basinSum + nineCount}");
        return basinSizes.TakeLast(3).Aggregate((result, next) => result * next);

        // not 1306692 - too low
    }

    private static int GetBasinSize(int[,] map, (int x, int y) lowPoint)
    {
        var baseBasinPoints = GetRowSection(map.GetRow(lowPoint.x), lowPoint.y).ToArray();
        var result = baseBasinPoints.Length;
        // search above
        var basinPoints = baseBasinPoints;
        for (var x = lowPoint.x - 1; x >= 0; x--)
        {
            var newBasinPoints = new SortedSet<int>();
            foreach (var point in basinPoints)
            {
                if (map[x, point] != 9)
                {
                    if (!newBasinPoints.Contains(point))
                    {
                        foreach (var p in GetRowSection(map.GetRow(x), point))
                        {
                            newBasinPoints.Add(p);
                        }
                    }
                }
            }

            basinPoints = newBasinPoints.ToArray();
            result += basinPoints.Length;
        }

        // search below
        basinPoints = baseBasinPoints;
        for (var x = lowPoint.x + 1; x < map.Rows(); x++)
        {
            var newBasinPoints = new SortedSet<int>();
            foreach (var point in basinPoints)
            {
                if (map[x, point] != 9)
                {
                    if (!newBasinPoints.Contains(point))
                    {
                        foreach (var p in GetRowSection(map.GetRow(x), point))
                        {
                            newBasinPoints.Add(p);
                        }
                    }
                }
            }

            if (!newBasinPoints.Any())
            {
                break;
            }

            basinPoints = newBasinPoints.ToArray();
            result += basinPoints.Length;
        }

        return result;
    }

    private static IEnumerable<int> GetRowSection(int[] mapRow, int startIndex)
    {
        var lowerBoundary = GetBoundary(mapRow, startIndex, -1);
        var upperBoundary = GetBoundary(mapRow, startIndex, 1);
        for (int i = lowerBoundary; i <= upperBoundary; i++)
        {
            yield return i;
        }
    }

    private static int GetBoundary(int[] mapRow, int startIndex, int direction)
    {
        if (startIndex == 0 && direction == -1 || startIndex == mapRow.Length - 1 && direction == 1)
        {
            return startIndex;
        }

        var position = startIndex + direction;
        if (mapRow[position] == 9)
        {
            return startIndex;
        }

        return GetBoundary(mapRow, position, direction);
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