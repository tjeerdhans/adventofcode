namespace aoc2021;

public class DayFour : Day
{
    public DayFour() : base(4, 4512, 1924)
    {
    }

    protected override long GetFirstAnswer(string[] set)
    {
        // parse set
        var bingoCards = new List<int[,]>();
        var numbersDrawn = set[0].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
        var currentBingoCardIndex = -1;
        var currentRowIndex = 0;
        foreach (var s in set.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                currentBingoCardIndex++;
                currentRowIndex = 0;
                bingoCards.Add(new int[5, 5]);
                continue;
            }

            var rowBingoNumbers = s.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToInt32(n)).ToArray();
            for (int i = 0; i < 5; i++)
            {
                bingoCards[currentBingoCardIndex][currentRowIndex, i] = rowBingoNumbers[i];
            }

            currentRowIndex++;
        }

        // run through the drawn numbers, set marked numbers to -1
        foreach (var n in numbersDrawn)
        {
            // check bingo cards
            foreach (var bingoCard in bingoCards)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (bingoCard[i, j] == n)
                        {
                            bingoCard[i, j] = -1;
                            var bingoValue = GetBingoValue(bingoCard, i, j);
                            if (bingoValue != -1)
                            {
                                return bingoValue * n;
                            }
                        }
                    }
                }
            }
        }

        return 0;
    }

    private static int GetBingoValue(int[,] bingoCard, int row, int column)
    {
        var result = -1;
        var rowSum = 0;
        var columnSum = 0;
        for (int i = 0; i < 5; i++)
        {
            rowSum += bingoCard[row, i];
            columnSum += bingoCard[i, column];
        }

        if (rowSum == -5) // bingo, return sum of other numbers
        {
            result = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (bingoCard[i, j] != -1) // skip other marked numbers
                        {
                            result += bingoCard[i, j];
                        }
                    }
                }
            }
        }

        if (columnSum == -5) // bingo, return sum of other numbers
        {
            result = 0;
            for (int j = 0; j < 5; j++)
            {
                if (j != column)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (bingoCard[i, j] != -1) // skip other marked numbers
                        {
                            result += bingoCard[i, j];
                        }
                    }
                }
            }
        }

        return result;
    }

    protected override long GetSecondAnswer(string[] set)
    {
        // parse set
        var bingoCards = new List<int[,]>();
        var numbersDrawn = set[0].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
        var currentBingoCardIndex = -1;
        var currentRowIndex = 0;
        foreach (var s in set.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                currentBingoCardIndex++;
                currentRowIndex = 0;
                bingoCards.Add(new int[5, 5]);
                continue;
            }

            var rowBingoNumbers = s.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToInt32(n)).ToArray();
            for (int i = 0; i < 5; i++)
            {
                bingoCards[currentBingoCardIndex][currentRowIndex, i] = rowBingoNumbers[i];
            }

            currentRowIndex++;
        }

        // run through the drawn numbers, set marked numbers to -1
        foreach (var n in numbersDrawn)
        {
            // check bingo cards
            var bingoCardsToCheck = bingoCards.ToList();
            foreach (var bingoCard in bingoCardsToCheck)
            {
                var bingoValue = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (bingoCard[i, j] == n)
                        {
                            bingoCard[i, j] = -1;
                            bingoValue = GetBingoValue(bingoCard, i, j);
                            if (bingoValue != -1)
                            {
                                //bingoCard.value = bingoValue;
                                if (bingoCards.Count > 1)
                                {
                                    bingoCards.Remove(bingoCard);
                                    break;
                                }

                                return bingoValue * n;
                            }
                        }
                    }

                    if (bingoValue != -1)
                    {
                        break;
                    }
                }
            }
        }

        return 0;
    }
}