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
        var curr = SearchStartPosition();
        var dist = InitDist(curr);
        return CountCheats(dist);
    }

    private int CountCheats(int[,] dist)
    {
        var count = 0;

        for (var y = 0; y < _map.Length; y++)
        {
            for (var x = 0; x < _map[y].Length; x++)
            {
                if (dist[y, x] == -1)
                    continue;

                Position2D[] neighbours =
                [
                    new(x + 1, y - 1), // top right
                    new(x + 2, y), // right
                    new(x + 1, y + 1), // bottom right
                    new(x, y + 2), // bottom
                ];

                foreach (var neighbour in neighbours)
                {
                    if (neighbour.X == 0 || neighbour.Y == 0 || neighbour.X == _map[0].Length ||
                        neighbour.Y == _map.Length)
                        continue;
                    if (dist[neighbour.Y, neighbour.X] == -1)
                        continue;
                    if (Math.Abs(dist[neighbour.Y, neighbour.X] - dist[y, x]) >= threshold + 2)
                        count++;
                }
            }
        }

        return count;
    }

    private int[,] InitDist(Position2D curr)
    {
        var dist = new int[_map.Length, _map[0].Length];

        for (var y = 0; y < _map.Length; y++)
        {
            for (var x = 0; x < _map[y].Length; x++)
                dist[y, x] = -1;
        }

        dist[curr.Y, curr.X] = 0;
        
        while (_map[curr.Y][curr.X] != 'E')
        {
            Position2D[] neighbours =
            [
                curr with { X = curr.X - 1 },
                curr with { X = curr.X + 1 },
                curr with { Y = curr.Y - 1 },
                curr with { Y = curr.Y + 1 },
            ];
            foreach (var newCurr in neighbours)
            {
                if (newCurr.X == 0 || newCurr.Y == 0 || newCurr.X == _map[0].Length || newCurr.Y == _map.Length)
                    continue;
                if (_map[newCurr.Y][newCurr.X] == WallSymbol)
                    continue;
                if (dist[newCurr.Y, newCurr.X] != -1)
                    continue;

                dist[newCurr.Y, newCurr.X] = dist[curr.Y, curr.X] + 1;
                curr = newCurr;
            }
        }
        
        return dist;
    }

    private Position2D SearchStartPosition()
    {
        for (var y = 0; y < _map.Length; y++)
        {
            for (var x = 0; x < _map[y].Length; x++)
            {
                if (_map[y][x] == 'S')
                    return new Position2D(x, y);
            }
        }

        throw new Exception("Start not found");
    }
}