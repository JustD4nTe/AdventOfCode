using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day16;

public class PartTwo(string input) : Solution(input)
{
    private const char WallSymbol = '#';

    private const int WalkCost = 1;
    private const int TurnCost = 1000;

    public override long Solve()
    {
        var map = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();

        var reindeerPosition = new Position2D(1, map.Length - 2);
        var endPosition = new Position2D(map[0].Length - 2, 1);

        var finished = Pathfinding(map, reindeerPosition, endPosition, map.Length, map[0].Length);

        List<Reindeer?> reindeers = [finished];
        var paths = new List<Position2D>();

        while (reindeers.Count > 0)
        {
            var nextGen = new List<Reindeer?>();

            foreach (var reindeer in reindeers)
            {
                if (reindeer is null)
                    continue;
                paths.Add(reindeer.Position);
                map[reindeer.Position.Y][reindeer.Position.X] = 'O';
                if (reindeer.Prev is not null)
                    nextGen.AddRange(reindeer.Prev);
            }

            if (nextGen.Count == 0)
                break;

            reindeers = nextGen.Distinct(new ReindeerComparer()).ToList();
        }

        return paths.Distinct().Count();
    }

    private class ReindeerComparer : IEqualityComparer<Reindeer?>
    {
        public bool Equals(Reindeer? x, Reindeer? y)
        {
            if (x is null || y is null) return false;
            return x.Position == y.Position && x.Direction == y.Direction;
        }

        public int GetHashCode(Reindeer obj)
        {
            return HashCode.Combine(obj.Position, (int)obj.Direction, obj.Cost);
        }
    }

    private static Reindeer Pathfinding(char[][] map, Position2D start, Position2D end, int height, int length)
    {
        var reindeer = new Reindeer(start, Directions.Right, 0);

        var openSet = new PriorityQueue<Reindeer, int>();
        openSet.Enqueue(reindeer, 0);

        var visited = new List<Reindeer>();
        Reindeer? finished = null;

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            var visitedReindeer =
                visited.FirstOrDefault(x => x.Direction == current.Direction && x.Position == current.Position);

            if (visitedReindeer is not null)
            {
                if (Math.Abs(visitedReindeer.Cost - current.Cost) == 0)
                    visitedReindeer.Prev!.Add(current.Prev![0]);
                continue;
            }

            if ((finished is null && current.Position == end) ||
                (current.Position == finished?.Position && current.Cost == finished.Cost))
            {
                finished = current;
                continue;
            }

            visited.Add(current);

            var neighbours = GetNeighbours(map, current);

            foreach (var neighbour in neighbours)
            {
                neighbour.SetCost(current.Cost + neighbour.Cost);
                neighbour.Prev = [current];
                openSet.Enqueue(neighbour, neighbour.Cost);
            }
        }

        return finished ?? throw new Exception("No path found");
    }

    private class Reindeer(Position2D position, Directions direction, int cost)
    {
        public Position2D Position { get; } = position;
        public Directions Direction { get; } = direction;
        public int Cost { get; private set; } = cost;
        public List<Reindeer>? Prev { get; set; }

        public void SetCost(int newCost) => Cost = newCost;
    }

    private static List<Reindeer> GetNeighbours(char[][] map, Reindeer reindeer)
    {
        var currentPosition = reindeer.Position;
        var neighbours = new List<Reindeer>();
        switch (reindeer.Direction)
        {
            case Directions.Up:
            {
                var left = currentPosition with { X = currentPosition.X - 1 };
                if (map[left.Y][left.X] != WallSymbol)
                    neighbours.Add(new(left, Directions.Left, WalkCost + TurnCost));

                var up = currentPosition with { Y = currentPosition.Y - 1 };
                if (map[up.Y][up.X] != WallSymbol)
                    neighbours.Add(new(up, Directions.Up, WalkCost));

                var right = currentPosition with { X = currentPosition.X + 1 };
                if (map[right.Y][right.X] != WallSymbol)
                    neighbours.Add(new(right, Directions.Right, WalkCost + TurnCost));
                break;
            }
            case Directions.Right:
            {
                var up = currentPosition with { Y = currentPosition.Y - 1 };
                if (map[up.Y][up.X] != WallSymbol)
                    neighbours.Add(new(up, Directions.Up, WalkCost + TurnCost));

                var right = currentPosition with { X = currentPosition.X + 1 };
                if (map[right.Y][right.X] != WallSymbol)
                    neighbours.Add(new(right, Directions.Right, WalkCost));

                var down = currentPosition with { Y = currentPosition.Y + 1 };
                if (map[down.Y][down.X] != WallSymbol)
                    neighbours.Add(new(down, Directions.Down, WalkCost + TurnCost));
                break;
            }
            case Directions.Down:
            {
                var right = currentPosition with { X = currentPosition.X + 1 };
                if (map[right.Y][right.X] != WallSymbol)
                    neighbours.Add(new(right, Directions.Right, WalkCost + TurnCost));

                var down = currentPosition with { Y = currentPosition.Y + 1 };
                if (map[down.Y][down.X] != WallSymbol)
                    neighbours.Add(new(down, Directions.Down, WalkCost));

                var left = currentPosition with { X = currentPosition.X - 1 };
                if (map[left.Y][left.X] != WallSymbol)
                    neighbours.Add(new(left, Directions.Left, WalkCost + TurnCost));
                break;
            }
            case Directions.Left:
            default:
            {
                var up = currentPosition with { Y = currentPosition.Y - 1 };
                if (map[up.Y][up.X] != WallSymbol)
                    neighbours.Add(new(up, Directions.Up, WalkCost + TurnCost));

                var left = currentPosition with { X = currentPosition.X - 1 };
                if (map[left.Y][left.X] != WallSymbol)
                    neighbours.Add(new(left, Directions.Left, WalkCost));

                var down = currentPosition with { Y = currentPosition.Y + 1 };
                if (map[down.Y][down.X] != WallSymbol)
                    neighbours.Add(new(down, Directions.Down, WalkCost + TurnCost));
                break;
            }
        }

        return neighbours;
    }
}