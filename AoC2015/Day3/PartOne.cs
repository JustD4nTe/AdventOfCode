namespace AoC2015.Day3;

public class PartTwo
{
    private const string inputFile = "Day3/input.txt";

    public long Solve()
    {
        var input = File.ReadAllLines(inputFile)[0].ToCharArray();

        var santaPosition = new Position(0, 0);
        var roboSantaPosition = new Position(0, 0);
        var houseTracker = new HashSet<Position>() { santaPosition };

        for(var i = 0; i < input.Length; i += 2)
        {
            santaPosition = Move(input[i], santaPosition);
            roboSantaPosition = Move(input[i + 1], roboSantaPosition);

            houseTracker.Add(santaPosition);
            houseTracker.Add(roboSantaPosition);
        }

        return houseTracker.Count;
    }

    private Position Move(char input, Position position) 
        => input switch
        {
            '^' => position with { Y = position.Y + 1 },
            'v' => position with { Y = position.Y - 1 },
            '>' => position with { X = position.X + 1 },
            '<' => position with { X = position.X - 1 },
            _ => throw new NotImplementedException()
        };

    private record Position(long X, long Y);
}