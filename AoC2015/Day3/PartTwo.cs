namespace AoC2015.Day3;

static class PartOne
{
    private const string inputFile = "Day3/input.txt";

    public static long Solve()
    {
        var input = File.ReadAllLines(inputFile)[0].ToCharArray();

        var santaPosition = new Position(0, 0);
        var houseTracker = new HashSet<Position>() { santaPosition };

        foreach (var direction in input)
        {
            santaPosition = direction switch
            {
                '^' => santaPosition with { Y = santaPosition.Y + 1 },
                'v' => santaPosition with { Y = santaPosition.Y - 1 },
                '>' => santaPosition with { X = santaPosition.X + 1 },
                '<' => santaPosition with { X = santaPosition.X - 1 },
                _ => throw new NotImplementedException()
            };

            houseTracker.Add(santaPosition);
        }

        return houseTracker.Count;
    }

    private record Position(long X, long Y);
}