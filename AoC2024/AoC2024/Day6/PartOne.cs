using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day6;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var map = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var guardPosition = SearchGuardPosition(map);
        var guardDirection = Directions.Up;

        do
        {
            switch (guardDirection)
            {
                case Directions.Up:
                    if (guardPosition.Y - 1 >= 0 && map[guardPosition.Y - 1][guardPosition.X] == '#')
                    {
                        guardDirection = Directions.Right;
                    }
                    else
                    {
                        map[guardPosition.Y][guardPosition.X] = 'X';
                        guardPosition = guardPosition.MoveUp();
                    }

                    break;
                case Directions.Down:
                    if (guardPosition.Y + 1 < map.Length && map[guardPosition.Y + 1][guardPosition.X] == '#')
                    {
                        guardDirection = Directions.Left;
                    }
                    else
                    {
                        map[guardPosition.Y][guardPosition.X] = 'X';
                        guardPosition = guardPosition.MoveDown();
                    }
                    break;
                case Directions.Left:
                    if (guardPosition.X - 1 >= 0 && map[guardPosition.Y][guardPosition.X - 1] == '#')
                    {
                        guardDirection = Directions.Up;
                    }
                    else
                    {
                        map[guardPosition.Y][guardPosition.X] = 'X';
                        guardPosition = guardPosition.MoveLeft();
                    }
                    break;
                case Directions.Right:
                    if (guardPosition.X + 1 < map[guardPosition.Y].Length && map[guardPosition.Y][guardPosition.X + 1] == '#')
                    {
                        guardDirection = Directions.Down;
                    }
                    else
                    {
                        map[guardPosition.Y][guardPosition.X] = 'X';
                        guardPosition = guardPosition.MoveRight();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        } while (IsGuardInsideMap(guardPosition, map));

        return map.Sum(x => x.Count(y => y == 'X'));
    }

    private static Position SearchGuardPosition(char[][] map)
    {
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '^')
                {
                    return new Position(x, y);
                }
            }
        }

        return new Position(0, 0);
    }

    private static bool IsGuardInsideMap(Position guardPosition, char[][] map)
        => guardPosition is { X: >= 0, Y: >= 0 } && guardPosition.X < map[0].Length && guardPosition.Y < map.Length;
}