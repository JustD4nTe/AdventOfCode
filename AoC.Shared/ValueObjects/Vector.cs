namespace AoC.Shared.ValueObjects;

public record Vector(int X, int Y)
{
    public Position CalculatePosition(Position p)
        => new(X + p.X, Y + p.Y);
}