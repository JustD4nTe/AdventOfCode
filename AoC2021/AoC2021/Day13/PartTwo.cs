using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day13;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var dots = rawInput[0]
            .Split("\r\n")
            .Select(x => x
                .Split(",")
                .Select(int.Parse)
                .ToArray())
            .Select(x => new Position2D(x[0], x[1]))
            .ToArray();

        var folds = rawInput[1].Split("\r\n").Select(x => x.Split(" ")[^1].Split("=")).ToArray();
        foreach (var fold in folds)
        {
            var axis = fold[0];
            var lineNumber = int.Parse(fold[1]);

            var newDots = new List<Position2D>();

            if (axis == "x")
            {
                foreach (var dot in dots)
                {
                    if (dot.X < lineNumber)
                        newDots.Add(dot);
                    else
                        newDots.Add(dot with { X = lineNumber - (dot.X - lineNumber) });
                }
            }
            else
            {
                foreach (var dot in dots)
                {
                    if (dot.Y < lineNumber)
                        newDots.Add(dot);
                    else
                        newDots.Add(dot with { Y = lineNumber - (dot.Y - lineNumber) });
                }
            }

            dots = newDots.Distinct().ToArray();
        }

        var maxX = dots.Max(x => x.X) + 1;
        var maxY = dots.Max(x => x.Y) + 1;

        var grid = ArrayHelper.InitMap(maxX, maxY, '.');
        foreach (var (x, y) in dots)
            grid[y][x] = '#';

        for (var y = 0; y < maxY; y++)
        {
            for (var x = 0; x < maxX; x++)
                Console.Write(grid[y][x]);
            Console.WriteLine();
        }

        return -1;
    }
}