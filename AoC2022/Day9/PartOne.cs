namespace AoC2022.Day9;

internal static class PartOne
{
    enum Direction { U, D, L, R };

    record Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public void MoveUp() => Y++;
        public void MoveDown() => Y--;
        public void MoveLeft() => X--;
        public void MoveRigth() => X++;

        public int GetAbsX() => Math.Abs(X);
        public int GetAbsY() => Math.Abs(Y);
    }

    record Tail
    {
        public Coordinate Position{ get; set; }

        public readonly HashSet<Coordinate> VisitedPositions;

        public Tail(Coordinate position)
        {
            Position = position;
            VisitedPositions = new() { Position };
        }

        private static int GetDistance(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            return Math.Abs(a - b);
        }

        public void Follow(Coordinate headPosition)
        {
            if (headPosition == Position
                || GetDistance(headPosition.X, Position.X) == 1 && headPosition.Y == Position.Y
                || GetDistance(headPosition.Y, Position.Y) == 1 && headPosition.X == Position.X
                || GetDistance(headPosition.X, Position.X) == 1 && GetDistance(headPosition.Y, Position.Y) == 1)
            {
                return;
            }

            if (headPosition.X == Position.X)
            {
                if (headPosition.Y > Position.Y)
                    Position.MoveUp();
                else
                    Position.MoveDown();
            }
            else if (headPosition.Y == Position.Y)
            {
                if (headPosition.X > Position.X)
                    Position.MoveRigth();
                else
                    Position.MoveLeft();
            }

            else if (headPosition.Y - Position.Y == 2 && headPosition.X - Position.X == 1
                  || headPosition.Y - Position.Y == 1 && headPosition.X - Position.X == 2)
            {
                Position.MoveUp();
                Position.MoveRigth();
            }

            else if (Position.Y - headPosition.Y == 1 && headPosition.X - Position.X == 2
                  || Position.Y - headPosition.Y == 2 && headPosition.X - Position.X == 1)
            {
                Position.MoveDown();
                Position.MoveRigth();
            }

            else if (Position.Y - headPosition.Y == 2 && Position.X - headPosition.X == 1
                  || Position.Y - headPosition.Y == 1 && Position.X - headPosition.X == 2)
            {
                Position.MoveDown();
                Position.MoveLeft();
            }
            else
            {
                Position.MoveUp();
                Position.MoveLeft();
            }

            VisitedPositions.Add(Position);
        }
    }

    record Head(Tail Tail, Coordinate Position)
    {
        public void Move(Direction direction, int steps)
        {
            for (var stepCounter = 0; stepCounter < steps; stepCounter++)
            {
                if (direction == Direction.U)
                    Position.MoveUp();
                else if (direction == Direction.D)
                    Position.MoveDown();
                else if (direction == Direction.L)
                    Position.MoveLeft();
                else
                    Position.MoveRigth();

                Tail.Follow(Position);
             }
        }
    };

    public static long Solution()
    {
        var tail = new Tail(new());
        var head = new Head(tail, new());

        foreach (var line in File.ReadAllLines("Day9/input.txt"))
        {
            var buff = line.Split(" ");
            var direction = Enum.Parse<Direction>(buff[0]);
            var steps = int.Parse(buff[1]);

            head.Move(direction, steps);
        }

        return head.Tail.VisitedPositions.Count;
    }
}