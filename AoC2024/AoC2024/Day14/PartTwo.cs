using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day14;

public class PartTwo(string input, int wide, int tall) : Solution(input)
{
    private const int Time = 100_000;

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
            .Select(x => new Robot(new Position2D(x[0][0], x[0][1]), new Vector(x[1][0], x[1][1])))
            .ToArray();
        
        for (var i = 0; i < Time; i++)
        {
            var bmp = new Bitmap(wide, tall);
            
            foreach (var robot in robots)
            {
                robot.Move(wide, tall);
                bmp.SetPixel(robot.Position.X, robot.Position.Y, Color.LimeGreen);
            }
            
            bmp.Save($"Day14/{i}.png", ImageFormat.Png);
        }

        return -1;
    }

    private class Robot(Position2D position, Vector vector)
    {
        public Position2D Position { get; private set; } = position;
        private Vector Vector { get; } = vector;

        public void Move(int wide, int tall)
        {
            var newX = TeleportThroughEdge(Position.X + Vector.X, wide);
            var newY = TeleportThroughEdge(Position.Y + Vector.Y, tall);
            Position = new Position2D(newX, newY);
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