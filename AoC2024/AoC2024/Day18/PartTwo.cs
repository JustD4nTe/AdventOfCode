using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.Helpers;
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
            .ToArray()
            .AsSpan();

        var start = new Position(0, 0);
        var end = new Position(memorySpaceSize, memorySpaceSize);

        var hi = corrupted.Length - 1;
        var mid = (int)Math.Round(hi / 2.0);
        var lo = 0;
        
        while (lo != hi && hi != mid)
        {
            var visited = ArrayHelper.InitMap<bool>(Height, Length);
            ArrayHelper.Fill(visited, corrupted[..mid], true);

            if (Pathfinding(visited, start, end))
                lo = mid;
            else
                hi = mid;
            
            mid = (int)Math.Round((hi + lo) / 2.0);
        }

        Console.WriteLine(corrupted[lo]);

        return -1;
    }

    private bool Pathfinding(bool[][] visited, Position start, Position end)
    {
        // to be discovered
        var openSet = new Queue<Position>();
        openSet.Enqueue(start);

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            if (visited[current.Y][current.X])
                continue;
            
            visited[current.Y][current.X] = true;

            if (current == end)
                return true;

            var neighbours = GetNeighbours(current);
            
            foreach(var neighbour in neighbours)
                openSet.Enqueue(neighbour);
        }

        return false;
    }

    private List<Position> GetNeighbours(Position current)
    {
        var neighbours = new List<Position>();

        if (current.Y + 1 < Height)
            neighbours.Add(current with { Y = current.Y + 1 });

        if (current.Y - 1 >= 0)
            neighbours.Add(current with { Y = current.Y - 1 });

        if (current.X + 1 < Length)
            neighbours.Add(current with { X = current.X + 1 });

        if (current.X - 1 >= 0)
            neighbours.Add(current with { X = current.X - 1 });

        return neighbours;
    }
}