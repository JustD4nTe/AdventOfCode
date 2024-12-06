namespace AoC.Shared.ValueObjects;

public record Position(int X, int Y)
{
    public Position MoveUp() => new Position(X, Y - 1); 
    public Position MoveLeft() => new Position(X - 1, Y); 
    public Position MoveDown() => new Position(X, Y + 1);
    public Position MoveRight() => new Position(X + 1, Y); 
}