using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2023.Day18;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var digPlans = File.ReadAllLines(input).Select(ParseInput);
        var trench = StartDigging(digPlans);
        // PrintTerrain(trench.Select(x => x.Position).ToList());
        var insideTrench = FillTrench(trench);
        var result = trench.Select(x => x.Position).Union(insideTrench).Distinct().ToList();
        // PrintTerrain(result);

        return result.Count;
    }

    private static Position[] FillTrench(Hole[] trench)
    {
        var minY = trench.Min(t => t.Position.Y);
        var maxY = trench.Max(t => t.Position.Y);

        var regex = new Regex("[#]+");

        var insideTrench = new List<Position>();

        for (var y = minY; y <= maxY; y++)
        {
            var row = trench.Where(t => t.Position.Y == y)
                            .OrderBy(t => t.Position.X)
                            .ToList();

            var startX = row[0].Position.X;
            var endX = row[^1].Position.X;

            // single horizontal wall
            if (endX - startX == row.Count - 1)
                continue;

            for (var x = startX + 1; x < endX; x++)
            {
                if (row.Any(r => r.Position.X == x))
                    continue;

                var nearestLeftBorder = row.Last(r => r.Position.X < x)!;
                var nearestRightBorder = row.First(r => r.Position.X > x)!;
                
                if (nearestLeftBorder.Direction is not Direction.Down
                    && nearestRightBorder.Direction is not Direction.Up)
                {
                    insideTrench.Add(new(x, y));
                }
            }
        }

        return [.. insideTrench];
    }

    private static void PrintTerrain(List<Position> holes)
    {
        var minY = holes.Min(t => t.Y) - 1;
        var maxY = holes.Max(t => t.Y) + 1;
        var minX = holes.Min(t => t.X) - 1;
        var maxX = holes.Max(t => t.X) + 1;

        for (var y = minY; y <= maxY; y++)
        {
            for (var x = minX; x <= maxX; x++)
            {
                var foo = holes.Any(h => h.X == x && h.Y == y);
                Console.Write(foo ? '#' : '.');
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static Hole[] StartDigging(IEnumerable<DigPlan> digPlans)
    {
        var currPosition = new Position(0, 0);
        var trench = new List<Hole>() { new(currPosition, Direction.Right) };

        foreach (var digPlan in digPlans)
        {
            var diggedGround = Dig(currPosition, digPlan.Direction, digPlan.Length);

            currPosition = diggedGround[^1].Position;
            trench.AddRange(diggedGround);
        }

        return [.. trench.Distinct().OrderBy(x => x.Position.Y)];
    }

    private static Hole[] Dig(Position currPosition, Direction direction, int length)
        => direction switch
        {
            Direction.Up => DigUp(currPosition, length),
            Direction.Right => DigRight(currPosition, length),
            Direction.Down => DigDown(currPosition, length),
            Direction.Left => DigLeft(currPosition, length),
            _ => throw new Exception()
        };

    private static Hole[] DigUp(Position currPosition, int length)
        => Enumerable.Range(1, length).Select(i => new Hole(currPosition.GetNew(yDiff: -i), Direction.Up)).ToArray();
    private static Hole[] DigRight(Position currPosition, int length)
        => Enumerable.Range(1, length).Select(i => new Hole(currPosition.GetNew(xDiff: i), Direction.Right)).ToArray();
    private static Hole[] DigDown(Position currPosition, int length)
        => Enumerable.Range(1, length).Select(i => new Hole(currPosition.GetNew(yDiff: i), Direction.Down)).ToArray();
    private static Hole[] DigLeft(Position currPosition, int length)
        => Enumerable.Range(1, length).Select(i => new Hole(currPosition.GetNew(xDiff: -i), Direction.Left)).ToArray();

    private static DigPlan ParseInput(string input)
    {
        var buff = input.Split(" ");

        var direction = buff[0] switch
        {
            "U" => Direction.Up,
            "R" => Direction.Right,
            "D" => Direction.Down,
            "L" => Direction.Left,
            _ => throw new Exception()
        };
        var length = int.Parse(buff[1]);
        var hexColor = buff[2][1..^1];

        return new(direction, length, hexColor);
    }

    private enum Direction { Up, Right, Down, Left };
    private record DigPlan(Direction Direction, int Length, string HexColor);
    private record Position(int X, int Y)
    {
        public Position GetNew(int? xDiff = null, int? yDiff = null)
            => new(X + (xDiff ?? 0), Y + (yDiff ?? 0));
    }
    private record Hole(Position Position, Direction Direction);
}