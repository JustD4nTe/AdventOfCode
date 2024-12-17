using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day15;

public class PartTwo(string input) : Solution(input)
{
    private const char EmptySymbol = '.';
    private const char RobotSymbol = '@';
    private const char WallSymbol = '#';
    private const char LeftBoxSymbol = '[';
    private const char RightBoxSymbol = ']';

    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var warehouseMap = rawInput[0]
            .Replace("#", "##")
            .Replace("O", "[]")
            .Replace(".", "..")
            .Replace("@", "@.")
            .Split("\r\n")
            .Select(x => x.ToCharArray())
            .ToArray();
        var robotMoves = rawInput[1].Split("\r\n").SelectMany(x => x.ToCharArray()).ToArray();

        var robotPosition = SearchRobotPosition(warehouseMap);
        // ShowWarehouse(warehouseMap);
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
            for (var x = 2; x < warehouseMap[y].Length - 2; x++)
            {
                if (warehouseMap[y][x] != LeftBoxSymbol)
                    continue;

                sum += 100 * y + x;
            }
        }

        return sum;
    }

    private static void StartRobot(char[] robotMoves, Position robotPosition, char[][] warehouseMap)
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

            // Console.WriteLine("Direction: " + direction);
            var nextPosition = GetNextPosition(robotPosition, direction);

            var canMove = TryToMove([nextPosition], direction, warehouseMap);
            if (canMove)
            {
                warehouseMap[robotPosition.Y][robotPosition.X] = EmptySymbol;

                robotPosition = nextPosition;

                warehouseMap[robotPosition.Y][robotPosition.X] = RobotSymbol;
            }

            // ShowWarehouse(warehouseMap);
        }
    }

    private static Position SearchRobotPosition(char[][] warehouseMap)
    {
        for (var y = 0; y < warehouseMap.Length; y++)
        {
            for (var x = 0; x < warehouseMap[y].Length; x++)
            {
                if (warehouseMap[y][x] != RobotSymbol)
                    continue;

                return new Position(x, y);
            }
        }

        throw new Exception("Could not find robot position");
    }

    private static bool TryToMove(List<Position> positionsToCheck, Directions direction,
        char[][] warehouseMap)
    {
        var emptySymbolCounter = 0;
        var nextPositionsToCheck = new List<Position>();
        var positionsWithBoxes = new List<Position>();

        foreach (var positionToCheck in positionsToCheck)
        {
            if (warehouseMap[positionToCheck.Y][positionToCheck.X] == WallSymbol)
                return false;

            if (warehouseMap[positionToCheck.Y][positionToCheck.X] == EmptySymbol)
                emptySymbolCounter++;

            else if (warehouseMap[positionToCheck.Y][positionToCheck.X] == LeftBoxSymbol)
            {
                positionsWithBoxes.Add(positionToCheck);
                positionsWithBoxes.Add(positionToCheck with { X = positionToCheck.X + 1 });

                switch (direction)
                {
                    case Directions.Up:
                        nextPositionsToCheck.Add(positionToCheck with { Y = positionToCheck.Y - 1 });
                        nextPositionsToCheck.Add(new Position(positionToCheck.X + 1, positionToCheck.Y - 1));
                        break;
                    case Directions.Right:
                        nextPositionsToCheck.Add(positionToCheck with { X = positionToCheck.X + 2 });
                        break;
                    case Directions.Down:
                        nextPositionsToCheck.Add(positionToCheck with { Y = positionToCheck.Y + 1 });
                        nextPositionsToCheck.Add(new Position(positionToCheck.X + 1, positionToCheck.Y + 1));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                }
            }
            else if (warehouseMap[positionToCheck.Y][positionToCheck.X] == RightBoxSymbol)
            {
                positionsWithBoxes.Add(positionToCheck with { X = positionToCheck.X - 1 });
                positionsWithBoxes.Add(positionToCheck);

                switch (direction)
                {
                    case Directions.Up:
                        nextPositionsToCheck.Add(positionToCheck with { Y = positionToCheck.Y - 1 });
                        nextPositionsToCheck.Add(new Position(positionToCheck.X - 1, positionToCheck.Y - 1));
                        break;
                    case Directions.Left:
                        nextPositionsToCheck.Add(positionToCheck with { X = positionToCheck.X - 2 });
                        break;
                    case Directions.Down:
                        nextPositionsToCheck.Add(positionToCheck with { Y = positionToCheck.Y + 1 });
                        nextPositionsToCheck.Add(new Position(positionToCheck.X - 1, positionToCheck.Y + 1));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                }
            }
        }

        if (emptySymbolCounter == positionsToCheck.Count)
            return true;

        var canMove = TryToMove(nextPositionsToCheck.Distinct().ToList(), direction, warehouseMap);
        if (!canMove)
            return false;

        if (direction == Directions.Right)
        {
            for (var i = positionsWithBoxes.Count - 1; i >= 0; i--)
            {
                var nextPosition = GetNextPosition(positionsWithBoxes[i], direction);
                warehouseMap[nextPosition.Y][nextPosition.X] = warehouseMap[positionsWithBoxes[i].Y][positionsWithBoxes[i].X];
                warehouseMap[positionsWithBoxes[i].Y][positionsWithBoxes[i].X] = EmptySymbol;
            }
        }
        else
        {
            foreach (var positionWithBox in positionsWithBoxes.Distinct())
            {
                var nextPosition = GetNextPosition(positionWithBox, direction);
                warehouseMap[nextPosition.Y][nextPosition.X] = warehouseMap[positionWithBox.Y][positionWithBox.X];
                warehouseMap[positionWithBox.Y][positionWithBox.X] = EmptySymbol;
            }
        }

        return true;
    }

    private static Position GetNextPosition(Position position, Directions direction)
        => direction switch
        {
            Directions.Left => position with { X = position.X - 1 },
            Directions.Right => position with { X = position.X + 1 },
            Directions.Up => position with { Y = position.Y - 1 },
            Directions.Down => position with { Y = position.Y + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
}