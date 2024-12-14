using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day14;

public class PartOne(string input, int wide, int tall) : Solution(input)
{
    private const int Time = 100;

    public override long Solve()
    {
        var robots = File.ReadAllLines(Input)
            .Select(x => x
                .Split(" ")
                .Select(y => y
                    .Split("=")[1]
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .Select(x => new Robot(new Position(x[0][0], x[0][1]), new Vector(x[1][0], x[1][1])))
            .ToArray();

        for (var i = 0; i < Time; i++)
        {
            foreach (var robot in robots)
                robot.Move(wide, tall);
        }

        var halfWide = wide / 2;
        var halfTall = tall / 2;

        var upLeft = robots.Count(x => x.Position.X < halfWide && x.Position.Y < halfTall);
        var upRight = robots.Count(x => x.Position.X > halfWide && x.Position.Y < halfTall);
        var downLeft = robots.Count(x => x.Position.X < halfWide && x.Position.Y > halfTall);
        var downRight = robots.Count(x => x.Position.X > halfWide && x.Position.Y > halfTall);

        return upLeft * upRight * downLeft * downRight;
    }

    private class Robot(Position position, Vector vector)
    {
        public Position Position { get; private set; } = position;
        private Vector Vector { get; } = vector;

        public void Move(int wide, int tall)
        {
            var newX = TeleportThroughEdge(Position.X + Vector.X, wide);
            var newY = TeleportThroughEdge(Position.Y + Vector.Y, tall);
            Position = new Position(newX, newY);
        }

        private static int TeleportThroughEdge(int value, int length)
        {
            if (value < 0)
                return length + value;
            if (value >= length)
                return value % length;
            
            return value;
        }
    }
}