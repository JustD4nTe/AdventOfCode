using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day6;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var map = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var guardPosition = SearchGuardPosition(map);

        // try put obstruction where guard was just walking
        var tempMap = map.Select(o => o.ToArray()).ToArray();
        StalkGuardWithNewObstruction(guardPosition, tempMap);
        var guardianPath = new List<Position>();
        
        for (var y = 0; y < tempMap.Length; y++)
        {
            for (var x = 0; x < tempMap[y].Length; x++)
            {
                if(tempMap[y][x] == 'X')
                    guardianPath.Add(new Position(x, y));
            }        
        }

        var optionalObstructions = 0;
        foreach (var position in guardianPath)
        {
            
            tempMap = map.Select(o => o.ToArray()).ToArray();
            tempMap[position.Y][position.X] = '#';
            
            if (StalkGuardWithNewObstruction(guardPosition, tempMap))
                optionalObstructions++;
        }
        
        return optionalObstructions;
    }

    private static bool StalkGuardWithNewObstruction(Position guardPosition, char[][] map)
    {
        var guardDirection = Directions.Up;
        do
        {
            switch (guardDirection)
            {
                case Directions.Up:
                    if (guardPosition.Y - 1 >= 0 && map[guardPosition.Y - 1][guardPosition.X] == '#')
                    {
                        guardDirection = Directions.Right;
                        if(IsGuardWalkThere(guardDirection, map, guardPosition))
                            return true;
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
                        if(IsGuardWalkThere(guardDirection, map, guardPosition))
                            return true;
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
                        if(IsGuardWalkThere(guardDirection, map, guardPosition))
                            return true;
                    }
                    else
                    {
                        map[guardPosition.Y][guardPosition.X] = 'X';
                        guardPosition = guardPosition.MoveLeft();
                    }

                    break;
                case Directions.Right:
                    if (guardPosition.X + 1 < map[guardPosition.Y].Length &&
                        map[guardPosition.Y][guardPosition.X + 1] == '#')
                    {
                        guardDirection = Directions.Down;
                        if(IsGuardWalkThere(guardDirection, map, guardPosition))
                            return true;
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

        return false;
    }

    private static bool IsGuardWalkThere(Directions guardDirection, char[][] map, Position guardPosition)
    {
        switch (guardDirection)
        {
            case Directions.Up:
                for (var y = guardPosition.Y; y >= 0; y--)
                {
                    if(map[y][guardPosition.X] == '#')
                        return true;
                    if(map[y][guardPosition.X] != 'X')
                        return false;
                }
                break;
            case Directions.Down:
                for (var y = guardPosition.Y; y < map.Length; y++)
                {
                    if(map[y][guardPosition.X] == '#')
                        return true;
                    if(map[y][guardPosition.X] != 'X')
                        return false;
                }
                break;
            case Directions.Left:
                for (var x = guardPosition.X; x >= 0; x--)
                {
                    if(map[guardPosition.Y][x] == '#')
                        return true;
                    if(map[guardPosition.Y][x] != 'X')
                        return false;
                }
                break; 
            case Directions.Right:
                for (var x = guardPosition.X; x < map[0].Length; x++)
                {
                    if(map[guardPosition.Y][x] == '#')
                        return true;
                    if(map[guardPosition.Y][x] != 'X')
                        return false;
                }
                break;
        }
        return false;
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