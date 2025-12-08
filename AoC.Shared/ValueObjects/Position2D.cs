namespace AoC.Shared.ValueObjects;

public record Position2D(int X, int Y)
{
    public Position2D MoveUp() => new(X, Y - 1);
    public Position2D MoveLeft() => new(X - 1, Y);
    public Position2D MoveDown() => new(X, Y + 1);
    public Position2D MoveRight() => new(X + 1, Y);

    public static Vector GetVector(Position2D p1, Position2D p2)
        => new(p2.X - p1.X, p2.Y - p1.Y);

    public bool IsInGrid(int maxX, int maxY)
        => X >= 0 && X < maxX && Y >= 0 && Y < maxY;

    public override string ToString() => $"({X}, {Y})";

    public Position2D[] GetBasicDirections()
        =>
        [
            this with { Y = Y - 1 },
            this with { X = X + 1 },
            this with { Y = Y + 1 },
            this with { X = X - 1 },
        ];

    public Position2D[] GetExtendedDirections()
        =>
        [
            .. GetBasicDirections(),
            new(X + 1, Y - 1),
            new(X + 1, Y + 1),
            new(X - 1, Y + 1),
            new(X - 1, Y - 1),
        ];
}