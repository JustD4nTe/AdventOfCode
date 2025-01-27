using AoC.Shared;

namespace AoC2023.Day16;

public class PartOne(string input) : Solution(input)
{
    private static bool[][] energizedGrid = [];
    public override long Solve()
    {
        var grid = File.ReadAllLines(Input)
                       .Select(x => x.ToCharArray()
                                     .Select(ParseInput)
                                     .ToArray())
                      .ToArray();

        energizedGrid = new bool[grid.Length][];
        for (var i = 0; i < grid.Length; i++)
        {
            energizedGrid[i] = new bool[grid[i].Length];
            Array.Fill(energizedGrid[i], false);
        }

        var beams = new Beam[] { new(0, 0, Direction.Down) };
        energizedGrid[0][0] = true;

        HashSet<Beam> existingBeams = [.. beams];

        while (beams.Length != 0)
        {
            beams = beams.SelectMany(x => x.Move(grid))
                         .Where(x => !existingBeams.Contains(x))
                         .ToArray();

            foreach (var beam in beams)
                existingBeams.Add(beam);

        };

        // PrintEnergizedGrid();

        return energizedGrid.Sum(x => x.Count(y => y));
    }

    private static void PrintEnergizedGrid()
    {
        for (var y = 0; y < energizedGrid.Length; y++)
        {
            for (var x = 0; x < energizedGrid[y].Length; x++)
                Console.Write(energizedGrid[y][x] ? '#' : '.');
            Console.WriteLine();
        }
    }

    private static Tile ParseInput(char symbol)
        => symbol switch
        {
            '.' => new EmptySpace(),
            '/' => new RightMirror(),
            '\\' => new LeftMirror(),
            '|' => new VerticalSplitter(),
            '-' => new HorizontalSplitter(),
            _ => throw new Exception("Unknown symbol")
        };

    private abstract record Tile(char Symbol)
    {
        public abstract Beam[] Handle(Beam beam);
    }

    private record EmptySpace() : Tile('.')
    {
        public override Beam[] Handle(Beam beam) => [beam.ChangeDirection(beam.Direction)];
    }

    private record RightMirror() : Tile('/')
    {
        public override Beam[] Handle(Beam beam)
            => beam.Direction switch
            {
                Direction.Up => [beam.ChangeDirection(Direction.Right)],
                Direction.Right => [beam.ChangeDirection(Direction.Up)],
                Direction.Down => [beam.ChangeDirection(Direction.Left)],
                Direction.Left => [beam.ChangeDirection(Direction.Down)],
                _ => throw new NotImplementedException(),
            };
    }

    private record LeftMirror() : Tile('\\')
    {
        public override Beam[] Handle(Beam beam)
            => beam.Direction switch
            {
                Direction.Up => [beam.ChangeDirection(Direction.Left)],
                Direction.Right => [beam.ChangeDirection(Direction.Down)],
                Direction.Down => [beam.ChangeDirection(Direction.Right)],
                Direction.Left => [beam.ChangeDirection(Direction.Up)],
                _ => throw new NotImplementedException(),
            };
    }

    private record VerticalSplitter() : Tile('|')
    {
        public override Beam[] Handle(Beam beam)
            => beam.Direction switch
            {
                Direction.Up => [beam.ChangeDirection(Direction.Up)],
                Direction.Down => [beam.ChangeDirection(Direction.Down)],
                _ => beam.SplitVertically(),
            };
    }

    private record HorizontalSplitter() : Tile('-')
    {
        public override Beam[] Handle(Beam beam)
            => beam.Direction switch
            {
                Direction.Left => [beam.ChangeDirection(Direction.Left)],
                Direction.Right => [beam.ChangeDirection(Direction.Right)],
                _ => beam.SplitHorizontal(),
            };
    }

    private enum Direction { Up, Right, Down, Left };
    private record Beam(int X, int Y, Direction Direction)
    {
        public Beam[] Move(Tile[][] grid)
        {
            var beam = ChangePosition(Direction);
            if (beam is null)
                return [];

            return grid[beam.Y][beam.X] switch
            {
                RightMirror mirror => mirror.Handle(beam),
                LeftMirror mirror => mirror.Handle(beam),
                VerticalSplitter splitter => splitter.Handle(beam),
                HorizontalSplitter splitter => splitter.Handle(beam),
                _ => [beam]
            };
        }

        public Beam? MoveUp()
        {
            var beam = new Beam(X, Y - 1, Direction.Up);
            return beam.IsInGrid() ? beam : null;
        }

        public Beam? MoveDown()
        {
            var beam = new Beam(X, Y + 1, Direction.Down);
            return beam.IsInGrid() ? beam : null;
        }

        public Beam? MoveLeft()
        {
            var beam = new Beam(X - 1, Y, Direction.Left);
            return beam.IsInGrid() ? beam : null;
        }

        public Beam? MoveRight()
        {
            var beam = new Beam(X + 1, Y, Direction.Right);
            return beam.IsInGrid() ? beam : null;
        }

        public Beam[] SplitHorizontal()
            => [ChangeDirection(Direction.Right), Copy(Direction.Left)];

        public Beam[] SplitVertically()
            => [ChangeDirection(Direction.Up), Copy(Direction.Down)];

        public Beam ChangeDirection(Direction direction) => new(X, Y, direction);

        private Beam Copy(Direction direction) => new(X, Y, direction);

        private Beam? ChangePosition(Direction direction)
            => direction switch
            {
                Direction.Up => MoveUp(),
                Direction.Right => MoveRight(),
                Direction.Down => MoveDown(),
                Direction.Left => MoveLeft(),
                _ => null
            };

        private bool IsInGrid()
        {
            var isInGrid = X >= 0 && X < energizedGrid[0].Length && Y >= 0 && Y < energizedGrid.Length;
            if (isInGrid)
                energizedGrid[Y][X] = true;
            return isInGrid;
        }
    }
}