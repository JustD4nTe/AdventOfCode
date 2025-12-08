using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day18;

public class PartOne(string input, int memorySpaceSize, int maxByteLength) : Solution(input)
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
            .Select(x => new Position2D(x[0], x[1]))
            .ToArray();

        if (corrupted.Length > maxByteLength)
            corrupted = corrupted[..maxByteLength];

        var start = new Position2D(0, 0);
        var end = new Position2D(memorySpaceSize, memorySpaceSize);

        return Pathfinding(corrupted, start, end);
    }

    private int Pathfinding(Position2D[] corrupted, Position2D start, Position2D end)
    {
        var openSet = new Queue<Position2D>();
        openSet.Enqueue(start);

        var mScore = ArrayHelper.InitMap(Height, Length, int.MaxValue);
        mScore[start.Y][start.X] = 0;

        var visited = ArrayHelper.InitMap<bool>(Height, Length);
        ArrayHelper.Fill(visited, corrupted, true);

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            if (visited[current.Y][current.X])
                continue;

            visited[current.Y][current.X] = true;

            var neighbours = GetNeighbours(current);

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

    private Position2D[] GetNeighbours(Position2D current)
    {
        var neighbours = new List<Position2D>();

        if (current.Y + 1 < Height)
            neighbours.Add(current with { Y = current.Y + 1 });

        if (current.Y - 1 >= 0)
            neighbours.Add(current with { Y = current.Y - 1 });

        if (current.X + 1 < Length)
            neighbours.Add(current with { X = current.X + 1 });

        if (current.X - 1 >= 0)
            neighbours.Add(current with { X = current.X - 1 });

        return neighbours.ToArray();
    }
}