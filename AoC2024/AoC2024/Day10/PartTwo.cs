using System.Text;
using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day10;

public class PartTwo(string input) : Solution(input)
{
    private readonly int[][] _map = File.ReadAllLines(input).Select(x => x.Select(y => int.Parse(y.ToString())).ToArray()).ToArray();

    public override long Solve()
    {
        return SearchForStartPositions().Sum(start => GoThroughTrailhead(start, 1).Count);
    }

    private List<Position2D> SearchForStartPositions()
    {
        var startPositions = new List<Position2D>();

        for (var y = 0; y < _map.Length; y++)
        {
            for (var x = 0; x < _map[y].Length; x++)
            {
                if (_map[y][x] == 0)
                    startPositions.Add(new Position2D(x, y));
            }
        }

        return startPositions;
    }

    private List<Position2D> GoThroughTrailhead(Position2D position, int height)
    {
        if (height - 1 == 9 && _map[position.Y][position.X] == 9)
            return [position];

        var visited = new List<Position2D>();
        
        if (position.Y - 1 >= 0 && _map[position.Y - 1][position.X] == height)
            visited.AddRange(GoThroughTrailhead(position.MoveUp(), height + 1));
        
        if (position.Y + 1 < _map.Length && _map[position.Y + 1][position.X] == height)
            visited.AddRange(GoThroughTrailhead(position.MoveDown(), height + 1));
        
        if (position.X - 1 >= 0 && _map[position.Y][position.X - 1] == height)
            visited.AddRange(GoThroughTrailhead(position.MoveLeft(), height + 1));
        
        if (position.X + 1 < _map[position.Y].Length && _map[position.Y][position.X + 1] == height)
            visited.AddRange(GoThroughTrailhead(position.MoveRight(), height + 1));

        return visited;
    }
}