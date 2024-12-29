using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day20;

public class PartTwo(string input, int threshold) : Solution(input)
{
    private char[][] _map = null!;

    private const char WallSymbol = '#';
    private const int MaxCheatTime = 20;

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

                for (var r = 2; r <= MaxCheatTime; r++)
                {
                    for (var yDiff = 0; yDiff <= r; yDiff++)
                    {
                        var xDiff = r - yDiff;
                        Position[] neighbours =
                        [
                            new(x + xDiff, y + yDiff),
                            new(x - xDiff, y + yDiff),
                            new(x + xDiff, y - yDiff),
                            new(x - xDiff, y - yDiff),
                        ];

                        foreach (var neighbour in neighbours)
                        {
                            if (neighbour.X <= 0 || neighbour.Y <= 0 || neighbour.X >= _map[0].Length || neighbour.Y >= _map.Length)
                                continue;
                            if (dist[neighbour.Y, neighbour.X] == -1)
                                continue;
                            if (dist[neighbour.Y, neighbour.X] - dist[y, x] >= threshold + r)
                                count++;
                        }
                    }
                }
            }
        }

        return count;
    }

    private int[,] InitDist(Position curr)
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
            Position[] neighbours =
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

    private Position SearchStartPosition()
    {
        for (var y = 0; y < _map.Length; y++)
        {
            for (var x = 0; x < _map[y].Length; x++)
            {
                if (_map[y][x] == 'S')
                    return new Position(x, y);
            }
        }

        throw new Exception("Start not found");
    }
}