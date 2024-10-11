namespace AoC2022.Day9;

internal static class PartTwo
{
    enum Direction { U, D, L, R };

    record Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void MoveUp() => Y++;
        public void MoveDown() => Y--;
        public void MoveLeft() => X--;
        public void MoveRight() => X++;
    }

    record Knot
    {
        public Position Position { get; } = new();

        private static int GetDistance(int a, int b) 
            => Math.Abs(Math.Abs(a) - Math.Abs(b));

        private bool IsClose(Position position) 
            => GetDistance(position.X, Position.X) <= 1 || GetDistance(position.Y, Position.Y) <= 1;

        public void Follow(Position prevPosition)
        {

            if (prevPosition == Position
                || GetDistance(prevPosition.X, Position.X) == 1 && prevPosition.Y == Position.Y
                || GetDistance(prevPosition.Y, Position.Y) == 1 && prevPosition.X == Position.X
                || GetDistance(prevPosition.X, Position.X) == 1 && GetDistance(prevPosition.Y, Position.Y) == 1)
            {
                return;
            }

            //if (IsClose(prevPosition))
            //    return;

            if (prevPosition.Y > Position.Y)
                Position.MoveUp();
            if (prevPosition.Y < Position.Y)
                Position.MoveDown();
            if (prevPosition.X > Position.X)
                Position.MoveRight();
            if (prevPosition.X < Position.X)
                Position.MoveLeft();
        }
    }

    public static long Solution()
    {
        var knots = Enumerable.Range(0, 10)
                              .Select(_ => new Knot())
                              .ToArray();

        var visited = new HashSet<Position>();

        DrawGrid(knots);

        foreach (var line in File.ReadAllLines("Day9/input.txt"))
        {
            //Console.WriteLine($"== {line} ==");

            var buff = line.Split(" ");
            var direction = Enum.Parse<Direction>(buff[0]);
            var steps = int.Parse(buff[1]);

            for (var stepCounter = 0; stepCounter < steps; stepCounter++)
            {
                if (direction == Direction.U)
                    knots[0].Position.MoveUp();
                else if (direction == Direction.D)
                    knots[0].Position.MoveDown();
                else if (direction == Direction.L)
                    knots[0].Position.MoveLeft();
                else
                    knots[0].Position.MoveRight();

                for (var i = 1; i < knots.Length; i++)
                    knots[i].Follow(knots[i - 1].Position);

                visited.Add(knots[^1].Position);

                //DrawGrid(knots);
            }
        }

        return visited.Count;
    }

    private static char? GetChar(Knot[] knots, int x, int y)
    {
        for (var i = 0; i < knots.Length; i++)
        {
            if (knots[i].Position.X == x && knots[i].Position.Y == y)
                return i.ToString()[0];
        }

        return '.';
    }

    private static void DrawGrid(Knot[] knots)
    {
        Console.Clear();

        for (var y = 21 - 1; y >= 0; y--)
        {
            for (var x = 0; x < 26; x++)
                Console.Write(GetChar(knots, x - 11, y - 5));
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}