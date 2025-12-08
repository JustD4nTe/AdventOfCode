using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day15;

public class PartOne(string input) : Solution(input)
{
    private const char EmptySymbol = '.';
    private const char RobotSymbol = '@';
    private const char WallSymbol = '#';
    private const char BoxSymbol = 'O';

    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var warehouseMap = rawInput[0].Split("\r\n").Select(x => x.ToCharArray()).ToArray();
        var robotMoves = rawInput[1].Split("\r\n").SelectMany(x => x.ToCharArray()).ToArray();

        var robotPosition = SearchRobotPosition(warehouseMap);

        StartRobot(robotMoves, robotPosition, warehouseMap);

        // ShowWarehouse(warehouseMap);

        return CalculateBoxGpsCoordinates(warehouseMap);
    }

    private static void ShowWarehouse(char[][] warehouseMap)
    {
        for (var y = 0; y < warehouseMap.Length; y++)
            Console.WriteLine(string.Join("", warehouseMap[y]));
    }

    private static long CalculateBoxGpsCoordinates(char[][] warehouseMap)
    {
        var sum = 0;

        for (var y = 1; y < warehouseMap.Length - 1; y++)
        {
            for (var x = 1; x < warehouseMap[y].Length - 1; x++)
            {
                if (warehouseMap[y][x] != BoxSymbol)
                    continue;

                sum += 100 * y + x;
            }
        }

        return sum;
    }

    private static void StartRobot(char[] robotMoves, Position2D robotPosition, char[][] warehouseMap)
    {
        foreach (var robotMove in robotMoves)
        {
            var direction = robotMove switch
            {
                '<' => Directions.Left,
                '>' => Directions.Right,
                '^' => Directions.Up,
                'v' => Directions.Down,
                _ => throw new ArgumentOutOfRangeException(nameof(robotMove), robotMove, null)
            };

            var nextPosition = GetNextPosition(robotPosition, direction);

            var canMove = TryToMove(nextPosition, direction, warehouseMap);
            if (canMove)
            {
                warehouseMap[robotPosition.Y][robotPosition.X] = EmptySymbol;

                robotPosition = nextPosition;

                warehouseMap[robotPosition.Y][robotPosition.X] = RobotSymbol;
            }
            
            // ShowWarehouse(warehouseMap);
        }
    }

    private static Position2D SearchRobotPosition(char[][] warehouseMap)
    {
        for (var y = 0; y < warehouseMap.Length; y++)
        {
            for (var x = 0; x < warehouseMap[y].Length; x++)
            {
                if (warehouseMap[y][x] != RobotSymbol)
                    continue;

                return new Position2D(x, y);
            }
        }

        throw new Exception("Could not find robot position");
    }

    private static bool TryToMove(Position2D currPosition, Directions direction, char[][] warehouseMap)
    {
        switch (warehouseMap[currPosition.Y][currPosition.X])
        {
            case EmptySymbol:
                return true;
            case WallSymbol:
                return false;
            case BoxSymbol:
            {
                var nextPosition = GetNextPosition(currPosition, direction);
                var canMove = TryToMove(nextPosition, direction, warehouseMap);

                if (!canMove)
                    return false;

                warehouseMap[nextPosition.Y][nextPosition.X] = BoxSymbol;

                return true;
            }
            default:
                return false;
        }
    }

    private static Position2D GetNextPosition(Position2D position, Directions direction)
        => direction switch
        {
            Directions.Left => position with { X = position.X - 1 },
            Directions.Right => position with { X = position.X + 1 },
            Directions.Up => position with { Y = position.Y - 1 },
            Directions.Down => position with { Y = position.Y + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
}