using AoC.Shared;

namespace AoC2023.Day10;

public class PartOne(string input) : Solution(input)
{
    private static readonly Dictionary<Direction, Move> Directions = new()
    {
        [Direction.West] = new(-1, 0, Direction.West),
        [Direction.North] = new(0, -1, Direction.North),
        [Direction.East] = new(1, 0, Direction.East),
        [Direction.South] = new(0, 1, Direction.South)
    };

    public override long Solve()
    {
        var field = File.ReadAllLines(Input)
                        .Select(x => x.ToCharArray()
                                      .Select(Convert)
                                      .ToArray())
                        .ToArray();

        // startPosition
        var sp = GetStartPosition(field);

        var possibleDirections = new List<Position>();

        field[sp.Y][sp.X] = Step.Create((Start)field[sp.Y][sp.X], 0);

        MoveFromStartPosition(field, sp, possibleDirections);
        GoThoughPipes(field, possibleDirections);

        return field.SelectMany(x => x).Where(x => x is Step).Max(x => ((Step)x).StepCount);
    }

    private static void MoveFromStartPosition(Tile[][] field, Position sp, List<Position> possibleDirections)
    {
        foreach (var direction in Directions.Values)
        {
            var oppositeDirection = GetOppositeDirection(direction.Direction);
            // nextPosition
            var np = sp.Move(direction);
            if (np.Validate(field) && field[np.Y][np.X] is Pipe pipe)
            {
                if (pipe.FirstSide == oppositeDirection || pipe.SecondSide == oppositeDirection)
                {
                    possibleDirections.Add(np);
                }
            }
        }
    }

    private static void GoThoughPipes(Tile[][] field, List<Position> possibleDirections)
    {
        var stepCounter = 1;

        do
        {
            var buff = possibleDirections.Distinct().ToArray();
            possibleDirections.Clear();
            foreach (var position in buff)
            {
                var pipe = (Pipe)field[position.Y][position.X];

                var nextPosition = pipe.MoveThrough(field, position);
                if (nextPosition is not null)
                    possibleDirections.Add(nextPosition);

                field[position.Y][position.X] = Step.Create(pipe, stepCounter);
            }

            stepCounter++;
        } while (possibleDirections.Count != 0);
    }

    private static Tile Convert(char symbol)
        => symbol switch
        {
            '|' => new Pipe(symbol, Direction.North, Direction.South),
            '-' => new Pipe(symbol, Direction.East, Direction.West),
            'L' => new Pipe(symbol, Direction.North, Direction.East),
            'J' => new Pipe(symbol, Direction.North, Direction.West),
            '7' => new Pipe(symbol, Direction.South, Direction.West),
            'F' => new Pipe(symbol, Direction.South, Direction.East),
            '.' => new Ground(symbol),
            'S' => new Start(symbol),
            _ => throw new Exception("Symbol is unrecognized.")
        };

    private static Position GetStartPosition(Tile[][] field)
    {
        for (var y = 0; y < field.Length; y++)
        {
            for (var x = 0; x < field[y].Length; x++)
            {
                if (field[y][x] is Start)
                    return new Position(x, y);
            }
        }

        throw new Exception("Start position is not found.");
    }

    private static Direction GetOppositeDirection(Direction direction)
        => direction switch
        {
            Direction.West => Direction.East,
            Direction.East => Direction.West,
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            _ => throw new Exception()
        };

    private record Tile(char Symbol);
    private record Start(char Symbol) : Tile(Symbol);
    private record Ground(char Symbol) : Tile(Symbol);
    private record Pipe(char Symbol, Direction FirstSide, Direction SecondSide) : Tile(Symbol)
    {
        public Position? MoveThrough(Tile[][] field, Position position)
        {
            var direction = Directions[FirstSide];
            var oppositeDirection = GetOppositeDirection(direction.Direction);
            var np = position.Move(direction);

            if (np.Validate(field) && field[np.Y][np.X] is Pipe firstSidePipe)
            {
                if (firstSidePipe.FirstSide == oppositeDirection || firstSidePipe.SecondSide == oppositeDirection)
                    return np;
            }

            direction = Directions[SecondSide];
            oppositeDirection = GetOppositeDirection(direction.Direction);
            np = position.Move(direction);

            if (np.Validate(field) && field[np.Y][np.X] is Pipe secondSidePipe)
            {
                if (secondSidePipe.FirstSide == oppositeDirection || secondSidePipe.SecondSide == oppositeDirection)
                    return np;
            }

            return null;
        }
    }
    private record Step(char Symbol, int StepCount) : Tile(Symbol)
    {
        public static Step Create(Start tile, int step) => new(tile.Symbol, step);
        public static Step Create(Pipe tile, int step) => new(tile.Symbol, step);
    }

    private enum Direction { West, North, East, South };

    private record Move(int X, int Y, Direction Direction);

    private record Position(int X, int Y)
    {
        public Position Move(Move move) => new(X + move.X, Y + move.Y);
        public bool Validate(Tile[][] field)
        {
            if (X < 0 || Y < 0)
                return false;

            if (field[Y][X] is Ground)
                return false;

            return true;
        }
    }
}