namespace AoC.Shared.ValueObjects;

public record Vector(int X, int Y)
{
    public Position2D CalculatePosition(Position2D p)
        => new(X + p.X, Y + p.Y);
}