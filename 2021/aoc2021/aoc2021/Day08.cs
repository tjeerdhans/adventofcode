using System.Net.Http.Headers;
using Accord.Math;

namespace aoc2021;

public class Day08 : Day
{
    public Day08() : base(8, 26, 61229)
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
        // segments:
        //  aaaa  
        // b    c 
        // b    c 
        //  dddd  
        // e    f 
        // e    f 
        //  gggg          

        var result = 0;
        foreach (var note in set)
        {
            var splitted = note.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var signalPatterns = splitted[0].Split(' ').Select(s=>new string(CharArraySorted(s))).ToList();
            var fourDigits = splitted[1].Split(' ').Select(s=> new string(CharArraySorted(s))).ToList();
            var digits = new Dictionary<string, int>
            {
                { signalPatterns.Single(p => p.Length == 2), 1 },
                { signalPatterns.Single(p => p.Length == 3), 7 },
                { signalPatterns.Single(p => p.Length == 4), 4 },
                { signalPatterns.Single(p => p.Length == 7), 8 }
            };
            var one = signalPatterns.Single(p => p.Length == 2);
            var seven = signalPatterns.Single(p => p.Length == 3);

            // determine segment c and f and the digit 6 by looking for a 6-segment digit without one of the 2-segment digit
            var six = signalPatterns.Single(p => p.Length == 6 && !one.All(p.Contains));
            digits.Add(signalPatterns.Single(p => p.Length == 6 && !one.All(p.Contains)), 6);
            var segmentC = one.Except(six).Single();
            var segmentF = one.Except(new [] {segmentC}).Single();

            // determine digit 2 by looking for the digit without segment f
            digits.Add(signalPatterns.Single(p => !p.Contains(segmentF)), 2);

            // determine digit 5 by looking for the 5-segment digit without segment c
            var five = signalPatterns.Single(p => p.Length == 5 && !p.Contains(segmentC));
            digits.Add(five, 5);

            // digit 3 is the remaining digit with 5-segments
            digits.Add(signalPatterns.Except(digits.Keys).Single(p => p.Length == 5), 3);

            // determine segment e by subtracting digit 5 from 6
            var segmentE = six.Except(five).Single();

            // digit 9 is the remaining digit without segment e
            digits.Add(signalPatterns.Except(digits.Keys).Single(d => !d.Contains(segmentE)), 9);

            // digit 0 is the remaining digit
            digits.Add(signalPatterns.Except(digits.Keys).Single(), 0);

            // determine the output value
            var outputValue = string.Empty;
            foreach (var digit in fourDigits)
            {
                outputValue += digits[digit];
            }

            result += int.Parse(outputValue);
        }

        return result;
    }

    private char[] CharArraySorted(string input)
    {
        var chars = input.ToArray();
        Array.Sort(chars);
        return chars;
    }
}