namespace AoC.Shared.ValueObjects;

public record Position(int X, int Y)
{
    public Position MoveUp() => new Position(X, Y - 1); 
    public Position MoveLeft() => new Position(X - 1, Y); 
    public Position MoveDown() => new Position(X, Y + 1);
    public Position MoveRight() => new Position(X + 1, Y); 
    
    public static Vector GetVector(Position p1, Position p2)
        => new(p2.X - p1.X, p2.Y - p1.Y);
    
    public bool IsInGrid(int maxX, int maxY) 
        => X >= 0 && X < maxX && Y >= 0 && Y < maxY;

    public override string ToString() => $"({X}, {Y})";
}