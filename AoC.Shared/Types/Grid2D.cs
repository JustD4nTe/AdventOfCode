using System.Collections;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC.Shared.Types;

public class Grid2D<T>
{
    private readonly T[][] _grid;

    public readonly int Height;
    public readonly int Length;
    
    public Grid2D(int length, int height)
    {
        _grid = ArrayHelper.InitMap<T>(length, height);
    }

    public Grid2D(T[][] input)
    {
        Height = input.Length;
        Length = input[0].Length;
        
        _grid = new T[Height][];
        
        for (var y = 0; y < Height; y++)
        {
            _grid[y] = new T[Length];
            
            for (var x = 0; x < Length; x++)
                _grid[y][x] = input[y][x];
        }
    }
    
    public T this[Position p]
    {
        get => _grid[p.Y][p.X];
        set => _grid[p.Y][p.X] = value;
    }

    public T this[int y, int x]
    {
        get => _grid[y][x];
        set => _grid[y][x] = value;
    }

    public bool IsValid(Position p) 
        => p.Y >= 0 && p.Y < Height && p.X >= 0 && p.X < Length;

    public IEnumerable<Position> GoThroughGrid()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                yield return new Position(x, y);
            }
        }
    }
}