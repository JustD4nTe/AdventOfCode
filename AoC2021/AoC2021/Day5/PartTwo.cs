using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day5;

public class PartTwo(string input) : Solution(input)
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
            var start = new Position2D(line[0][0], line[0][1]);
            var end = new Position2D(line[1][0], line[1][1]);
            
            if (start.X == end.X)
            {
                Horizontal(map, start, end);
            }
            else if (start.Y == end.Y)
            {
                Vertical(map, start, end);
            }
            else if (start.X == start.Y && end.X == end.Y)
            {
                // 1,1 -> 3,3
                if (start.X < end.X)
                    SymmetricDiagonal(map, start, end);
                // 3,3 -> 1,1
                else
                    SymmetricDiagonal(map, end, start);
            }
            // 9,7 -> 7,9
            else if (start.X > end.X && start.Y < end.Y)
            {
                CrazyDiagonal(map, start, end);
            }
            // 7,9 -> 9,7
            else if (start.X < end.X && start.Y > end.Y)
            {
                CrazyDiagonal(map, end, start);
            }
            // 5,6 -> 12,13
            else if (start.X < end.X && start.Y < end.Y)
            {
                Diagonal(map, start, end);
            }
            // 12,13 -> 5,6
            else
            {
                Diagonal(map, end, start);
            }
        }

        return map.Sum(x => x.Count(y => y > 1));
    }

    private static void Horizontal(int[][] map, Position2D start, Position2D end)
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

    private static void Vertical(int[][] map, Position2D start, Position2D end)
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

    private static void SymmetricDiagonal(int[][] map, Position2D start, Position2D end)
    {
        for (var i = start.X; i <= end.X; i++)
            map[i][i]++;
    }

    private static void CrazyDiagonal(int[][] map, Position2D start, Position2D end)
    {
        for (int x = start.X, y = start.Y; x >= end.X || y <= end.Y; x--, y++)
            map[y][x]++;
    }

    private static void Diagonal(int[][] map, Position2D start, Position2D end)
    {
        for (int x = start.X, y = start.Y; x <= end.X || y <= end.Y; x++, y++)
            map[y][x]++;
    }
}