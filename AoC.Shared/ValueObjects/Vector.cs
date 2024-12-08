namespace AoC.Shared.ValueObjects;

public record Vector(int A, int B)
{
    public Position CalculatePosition(Position p)
        => new(A + p.X, B + p.Y);
}