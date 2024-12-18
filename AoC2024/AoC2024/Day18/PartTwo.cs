using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day18;

public class PartTwo(string input, int memorySpaceSize) : Solution(input)
{
    private int Length { get; } = memorySpaceSize + 1;
    private int Height { get; } = memorySpaceSize + 1;

    public override long Solve()
    {
        var corrupted = File.ReadAllLines(Input)
            .Select(x => x
                .Split(",")
                .Select(int.Parse)
                .ToArray())
            .Select(x => new Position(x[0], x[1]))
            .ToArray();

        var start = new Position(0, 0);
        var end = new Position(memorySpaceSize, memorySpaceSize);

        for (var i = 0; i < corrupted.Length; i++)
        {
            var buff = corrupted[..(i + 1)];
            if(Pathfinding(buff, start, end) == int.MaxValue)
            {
                Console.WriteLine(buff[^1]);
                return -1;
            }
        }

        return Pathfinding(corrupted, start, end);
    }

    private int Pathfinding(Position[] corrupted, Position start, Position end)
    {
        // to be discovered
        var openSet = new Queue<Position>();
        openSet.Enqueue(start);

        // For node n, gScore[n] is the currently known cost of the cheapest path from start to n.
        var mScore = InitMap(Height, Length, int.MaxValue);
        mScore[start.Y][start.X] = 0;

        // var mVisited = InitMap(length, height, false);

        var visited = new List<Position>();

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            if (visited.Contains(current))
                continue;

            visited.Add(current);

            var neighbours = GetNeighbours(corrupted, current);

            foreach (var neighbour in neighbours)
            {
                var newScore = mScore[current.Y][current.X] + 1;
                if (newScore < mScore[neighbour.Y][neighbour.X])
                    mScore[neighbour.Y][neighbour.X] = newScore;

                openSet.Enqueue(neighbour);
            }
        }

        return mScore[end.Y][end.X];
    }

    private Position[] GetNeighbours(Position[] corrupted, Position current)
    {
        var neighbours = new List<Position>();

        if (current.Y + 1 < Height && !corrupted.Any(x => x.Y == current.Y + 1 && x.X == current.X))
            neighbours.Add(current with { Y = current.Y + 1 });

        if (current.Y - 1 >= 0 && !corrupted.Any(x => x.Y == current.Y - 1 && x.X == current.X))
            neighbours.Add(current with { Y = current.Y - 1 });

        if (current.X + 1 < Length && !corrupted.Any(x => x.Y == current.Y && x.X == current.X + 1))
            neighbours.Add(current with { X = current.X + 1 });

        if (current.X - 1 >= 0 && !corrupted.Any(x => x.Y == current.Y && x.X == current.X - 1))
            neighbours.Add(current with { X = current.X - 1 });

        return neighbours.ToArray();
    }

    private static T[][] InitMap<T>(int length, int height, T defaultValue)
    {
        var map = new T[height][];

        for (var y = 0; y < height; y++)
        {
            map[y] = new T[length];
            for (var x = 0; x < length; x++)
            {
                map[y][x] = defaultValue;
            }
        }

        return map;
    }
}