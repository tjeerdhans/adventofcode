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


        var lowPoints = GetLowPoints(heightMap);
        
        var heightMatrix = heightMap.ToMatrix();
        heightMatrix = heightMatrix.Apply(i => i != 9 ? 0 : 9);
        for (int x = 0; x < heightMatrix.Rows(); x++)
        {
            var row = heightMatrix.GetRow(x);
            Console.Write($"{x:00} ");
            Console.WriteLine(string.Join(' ', row.Select(i=>i==0?" ":"9")));
        }
        
        var basinSizes = new List<int>();
        foreach (var p in lowPoints)
        {
            basinSizes.Add(GetBasinSize(heightMatrix, p));
        }

        basinSizes.Sort();
        var nineCount = heightMap.Sum(x => x.Count(y => y == 9));
        var basinSum = basinSizes.Sum();
        Console.WriteLine(
            $"Basin sum + all nines should amount to all of the nodes ({heightMatrix.Length}): {basinSum + nineCount}");
        return basinSizes.TakeLast(3).Aggregate((result, next) => result * next);

        // not 1306692 - too low
    }

    private static int GetBasinSize(int[,] map, (int x, int y) lowPoint)
    {
        var baseBasinPoints = GetRowSection(map.GetRow(lowPoint.x), lowPoint.y).ToArray();
        var result = 0;
        // search above
        var basinPoints = baseBasinPoints;
        for (var x = lowPoint.x - 1; x >= 0; x--)
        {
            var newBasinPoints = new SortedSet<int>();
            foreach (var point in basinPoints.Where(p => map[x, p] != 9 && !newBasinPoints.Contains(p)))
            {
                var rowSection = GetRowSection(map.GetRow(x), point).ToArray();
                foreach (var p in rowSection)
                {
                    newBasinPoints.Add(p);
                }
            }

            if (!newBasinPoints.Any())
            {
                break;
            }

            basinPoints = newBasinPoints.ToArray();
            result += basinPoints.Length;
        }
        
        // recheck the base basin row (the one containing the low point)

        // search below
        basinPoints = baseBasinPoints;
        for (var x = lowPoint.x + 1; x < map.Rows(); x++)
        {
            var newBasinPoints = new HashSet<int>();
            foreach (var point in basinPoints.Where(p => map[x, p] != 9 && !newBasinPoints.Contains(p)))
            {
                var rowSection = GetRowSection(map.GetRow(x), point).ToArray();
                foreach (var p in rowSection)
                {
                    newBasinPoints.Add(p);
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
        var lowerBoundary = 0;
        for (var y = startIndex - 1; y >= -1; y--)
        {
            if (y == -1 || mapRow[y] == 9)
            {
                lowerBoundary = y + 1;
                break;
            }
        }

        var upperBoundary = 0;
        for (var y = startIndex + 1; y <= mapRow.Length; y++)
        {
            if (y == mapRow.Length || mapRow[y] == 9)
            {
                upperBoundary = y - 1;
                break;
            }
        }

        for (var i = lowerBoundary; i <= upperBoundary; i++)
        {
            yield return i;
        }
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