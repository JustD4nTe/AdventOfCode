using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day20;

public class PartOne(string input, int threshold) : Solution(input)
{
    private char[][] _map = null!;

    private const char WallSymbol = '#';

    public override long Solve()
    {
        _map = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var (start, end) = SearchTrackEndpoints();

        var basePath = Pathfinding(start, end, new Position(0, 0));
        var disabledWalls = GetDisabledWalls(GetPath(basePath));

        var i = 0;
        var counter = 0;
        // foreach (var disabledWall in disabledWalls)
        // {
        //     Console.WriteLine($"Checking {++i} of {disabledWalls.Length}");
        //     var runner = Pathfinding(start, end, disabledWall);
        //     if (basePath!.Cost - runner!.Cost >= 20)
        //         counter++;
        // }

        var tasks = disabledWalls.Select(disabledWall => Task.Run(() =>
        {
            Console.WriteLine($"Checking {Interlocked.Increment(ref i)} of {disabledWalls.Length}");
            var runner = Pathfinding(start, end, disabledWall);
            if (basePath!.Cost - runner!.Cost >= threshold)
                Interlocked.Increment(ref counter);
        })).ToArray();

        Task.WaitAll(tasks);
        
        return counter;
    }

    private (Position, Position) SearchTrackEndpoints()
    {
        Position start = null!, end = null!;
        for (var y = 0; y < _map.Length; y++)
        {
            for (var x = 0; x < _map[y].Length; x++)
            {
                switch (_map[y][x])
                {
                    case 'S':
                        start = new Position(x, y);
                        break;
                    case 'E':
                        end = new Position(x, y);
                        break;
                }
            }
        }

        return (start, end);
    }

    private class Runner(Position position, int cost = 1)
    {
        public Position Position { get; } = position;
        public int Cost { get; } = cost;

        public Runner? Prev { get; set; }
    }

    private class RunnerComparer : IEqualityComparer<Runner>
    {
        public bool Equals(Runner? x, Runner? y)
        {
            if (x is null || y is null) return false;
            return x.Position == y.Position;
        }

        public int GetHashCode(Runner obj)
        {
            return HashCode.Combine(obj.Position, obj.Cost);
        }
    }

    private List<Runner> GetNeighbours(Runner current, Position disabledWall)
    {
        var currentPosition = current.Position;
        var neighbours = new List<Runner>();

        var left = currentPosition with { X = currentPosition.X - 1 };
        if (left == disabledWall || _map[left.Y][left.X] != WallSymbol)
            neighbours.Add(new(left, current.Cost + 1));

        var up = currentPosition with { Y = currentPosition.Y - 1 };
        if (up == disabledWall || _map[up.Y][up.X] != WallSymbol)
            neighbours.Add(new(up, current.Cost + 1));

        var right = currentPosition with { X = currentPosition.X + 1 };
        if (right == disabledWall || _map[right.Y][right.X] != WallSymbol)
            neighbours.Add(new(right, current.Cost + 1));

        var down = currentPosition with { Y = currentPosition.Y + 1 };
        if (down == disabledWall || _map[down.Y][down.X] != WallSymbol)
            neighbours.Add(new(down, current.Cost + 1));

        return neighbours;
    }

    private Runner? Pathfinding(Position start, Position end, Position disabledWall)
    {
        var reindeer = new Runner(start, 0);

        var openSet = new PriorityQueue<Runner, int>();
        openSet.Enqueue(reindeer, 0);

        var visited = new List<Runner>();
        var finished = new List<Runner>();

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            if (visited.Contains(current, new RunnerComparer()))
                continue;

            if (current.Position == end)
                finished.Add(current);

            visited.Add(current);

            var neighbours = GetNeighbours(current, disabledWall);
            foreach (var neighbour in neighbours)
            {
                neighbour.Prev = current;
                openSet.Enqueue(neighbour, neighbour.Cost);
            }
        }

        return finished.OrderBy(x => x.Cost).FirstOrDefault();
    }

    private static Position[] GetPath(Runner? runner)
    {
        var path = new List<Position>();
        while (runner is not null)
        {
            path.Add(runner.Position);
            runner = runner.Prev;
        }

        return path.ToArray();
    }

    private Position[] GetDisabledWalls(Position[] paths)
    {
        var disabledWalls = new List<Position>();

        foreach (var path in paths)
        {
            disabledWalls.Add(path with { X = path.X - 1 });
            disabledWalls.Add(path with { X = path.X + 1 });
            disabledWalls.Add(path with { Y = path.Y - 1 });
            disabledWalls.Add(path with { Y = path.Y + 1 });
        }

        return disabledWalls.Distinct().Where(x => x is { Y: > 0, X: > 0 } && x.Y < _map.Length - 1 && x.X < _map[x.Y].Length - 1 && _map[x.Y][x.X] == WallSymbol).ToArray();
    }
}