using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day16;

public class PartOne(string input) : Solution(input)
{
    private const char WallSymbol = '#';

    private const int WalkCost = 1;
    private const int TurnCost = 1000;

    public override long Solve()
    {
        var map = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();

        var reindeerPosition = new Position(1, map.Length - 2);
        var endPosition = new Position(map[0].Length - 2, 1);

        return Pathfinding(map, reindeerPosition, endPosition);
    }

    private static int Pathfinding(char[][] map, Position start, Position end)
    {
        var reindeer = new Reindeer(start, Directions.Right, 0);

        var openSet = new PriorityQueue<Reindeer, int>();
        openSet.Enqueue(reindeer, 0);

        var visited = new List<Reindeer>();

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            if (visited.Contains(current, new ReindeerComparer()))
                continue;

            if (current.Position == end)
                return current.Cost;

            visited.Add(current);

            var neighbours = GetNeighbours(map, current);

            foreach (var neighbour in neighbours)
            {
                var newScore = current.Cost + neighbour.Cost;
                openSet.Enqueue(neighbour with { Cost = newScore }, newScore);
            }
        }

        return -1;
    }

    private record Reindeer(Position Position, Directions Direction, int Cost);

    private class ReindeerComparer : IEqualityComparer<Reindeer>
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