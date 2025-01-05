using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day5;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x
                .Split("->")
                .Select(y => y
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .ToArray();

        var maxX = rawInput.SelectMany(x => x.Select(y => y[0])).Max() + 1;
        var maxY = rawInput.SelectMany(x => x.Select(y => y[1])).Max() + 1;
        var map = ArrayHelper.InitMap<int>(maxX, maxY);

        foreach (var line in rawInput)
        {
            var start = new Position(line[0][0], line[0][1]);
            var end = new Position(line[1][0], line[1][1]);

            if (start.X == end.X)
                Horizontal(map, start, end);
            else if (start.Y == end.Y)
                Vertical(map, start, end);
        }

        return map.Sum(x => x.Count(y => y >= 2));
    }

    private static void Horizontal(int[][] map, Position start, Position end)
    {
        int startY, endY;
        var x = start.X;

        if (start.Y > end.Y)
        {
            startY = end.Y;
            endY = start.Y;
        }
        else
        {
            startY = start.Y;
            endY = end.Y;
        }

        for (var y = startY; y <= endY; y++)
            map[y][x]++;
    }

    private static void Vertical(int[][] map, Position start, Position end)
    {
        int startX, endX;

        if (start.X > end.X)
        {
            startX = end.X;
            endX = start.X;
        }
        else
        {
            startX = start.X;
            endX = end.X;
        }

        var y = start.Y;

        for (var x = startX; x <= endX; x++)
            map[y][x]++;
    }
}