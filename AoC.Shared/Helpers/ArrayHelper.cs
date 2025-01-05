using AoC.Shared.ValueObjects;

namespace AoC.Shared.Helpers;

public static class ArrayHelper
{
    public static T[][] InitMap<T>(int length, int height, T defaultValue)
    {
        var map = new T[height][];

        for (var y = 0; y < height; y++)
        {
            map[y] = new T[length];

            for (var x = 0; x < length; x++)
                map[y][x] = defaultValue;
        }

        return map;
    }

    public static T[][] InitMap<T>(int length, int height)
        => Enumerable.Range(0, height).Select(x => new T[length]).ToArray();

    public static void Fill<T>(T[][] map, Span<Position> positions, T value)
    {
        foreach (var p in positions)
            map[p.Y][p.X] = value;
    }

    public static T[][] GetPermutations<T>(T[] list, int length)
    {
        if (length == 1)
            return list.Select(x => new[] { x }).ToArray();

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => 
                !t.Contains(e)),
                (t1, t2) => t1.Concat([t2]).ToArray())
            .ToArray();
    }
}