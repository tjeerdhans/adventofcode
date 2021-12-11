namespace aoc2021;

public abstract class Day
{
    private readonly int _dayNumber;
    private readonly long _firstExpected;
    private readonly long _secondExpected;

    private readonly string[] _testSet;
    private readonly string[] _set;

    protected Day(int dayNumber, long firstExpected, long secondExpected)
    {
        _dayNumber = dayNumber;
        _firstExpected = firstExpected;
        _secondExpected = secondExpected;
        _set = File.ReadAllLines($"input{_dayNumber:00}.txt");
        _testSet = File.ReadAllLines($"input{_dayNumber:00}_test.txt");
    }

    public void Run()
    {
        First();
        Second();
        Console.WriteLine();
    }

    protected abstract long GetFirstAnswer(string[] set);
    protected abstract long GetSecondAnswer(string[] set);

    public void First()
    {
        var result = GetFirstAnswer(_testSet);
        if (result == _firstExpected)
        {
            Console.WriteLine($"Day {_dayNumber}: first test successful.");
            Console.WriteLine($"Day {_dayNumber}: first answer: {GetFirstAnswer(_set)}");
        }
        else
        {
            Console.WriteLine($"Day {_dayNumber}: first test failed with {result}");
        }
    }

    public void Second()
    {
        var result = GetSecondAnswer(_testSet);
        if (result == _secondExpected)
        {
            Console.WriteLine($"Day {_dayNumber}: second test successful.");
            Console.WriteLine($"Day {_dayNumber}: second answer: {GetSecondAnswer(_set)}");
        }
        else
        {
            Console.WriteLine($"Day {_dayNumber}: second test failed with {result}");
        }
    }
}