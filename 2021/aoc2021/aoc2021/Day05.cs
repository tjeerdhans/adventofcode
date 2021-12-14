namespace aoc2021;

public class Day05 : Day
{
    public Day05() : base(5, 5, 12)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        var coordinateHits = new Dictionary<(int x, int y), int>();
        foreach (var s in set)
        {
            var splitted = s.Split(" -> ");
            var x1y1 = splitted[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            var x2y2 = splitted[1].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            if (!(x1y1[0] == x2y2[0] || x1y1[1] == x2y2[1])) // look for horizontal and vertical lines
                continue;
            var x1 = x1y1[0];
            var y1 = x1y1[1];
            var x2 = x2y2[0];
            var y2 = x2y2[1];

            if (x1 == x2) // horizontal line
            {
                if (y1 > y2)
                    (y1, y2) = (y2, y1); // swap via deconstruction, thanks resharper!

                for (var i = y1; i <= y2; i++)
                {
                    if (!coordinateHits.ContainsKey((x1, i)))
                        coordinateHits.Add((x1, i), 1);
                    else
                        coordinateHits[(x1, i)]++;
                }
            }

            if (y1 == y2) // vertical line
            {
                if (x1 > x2)
                    (x1, x2) = (x2, x1); // swap via deconstruction, thanks resharper!

                for (var i = x1; i <= x2; i++)
                {
                    if (!coordinateHits.ContainsKey((i, y1)))
                        coordinateHits.Add((i, y1), 1);
                    else
                        coordinateHits[(i, y1)]++;
                }
            }
        }

        return coordinateHits.Count(h => h.Value >= 2);
    }

    protected override long GetSecondAnswer(string[] set)
    {
        var coordinateHits = new Dictionary<(int x, int y), int>();
        foreach (var s in set)
        {
            var splitted = s.Split(" -> ");
            var x1y1 = splitted[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            var x2y2 = splitted[1].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            var x1 = x1y1[0];
            var y1 = x1y1[1];
            var x2 = x2y2[0];
            var y2 = x2y2[1];

            if (x1 == x2) // horizontal line
            {
                if (y1 > y2)
                    (y1, y2) = (y2, y1);

                for (var i = y1; i <= y2; i++)
                {
                    if (!coordinateHits.ContainsKey((x1, i)))
                        coordinateHits.Add((x1, i), 1);
                    else
                        coordinateHits[(x1, i)]++;
                }
            }
            else if (y1 == y2) // vertical line
            {
                if (x1 > x2)
                    (x1, x2) = (x2, x1);

                for (var i = x1; i <= x2; i++)
                {
                    if (!coordinateHits.ContainsKey((i, y1)))
                        coordinateHits.Add((i, y1), 1);
                    else
                        coordinateHits[(i, y1)]++;
                }
            }
            else
            {
                var deltaX = x1 > x2 ? -1 : 1;
                var deltaY = y1 > y2 ? -1 : 1;
                for (int x = x1, y = y1; x != x2 && y != y2; x += deltaX, y += deltaY)
                {
                    if (!coordinateHits.ContainsKey((x, y)))
                        coordinateHits.Add((x, y), 1);
                    else
                        coordinateHits[(x, y)]++;
                }
                // add the end point
                if (!coordinateHits.ContainsKey((x2, y2)))
                    coordinateHits.Add((x2, y2), 1);
                else
                    coordinateHits[(x2, y2)]++;
            }
        }

        return coordinateHits.Count(h => h.Value >= 2);
    }
}