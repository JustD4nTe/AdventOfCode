using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day15;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x
                .ToCharArray().Select(y => byte.Parse(y.ToString()))
                .ToArray())
            .ToArray();

        var cave = new byte[rawInput.Length * 5][];

        for (var i = 0; i < cave.Length; i++)
            cave[i] = new byte[rawInput[0].Length * 5];

        for (var y = 0; y < rawInput.Length; y++)
        {
            for (var x = 0; x < rawInput[y].Length; x++)
                cave[y][x] = rawInput[y][x];
        }

        var offsetY = rawInput.Length; 
        var offsetX = rawInput[0].Length; 
        
        for (var y = 0; y < cave.Length; y++)
        {
            var oy = y % offsetY;
            var ky = y / offsetY;
            
            for (var x = 0; x < cave[y].Length; x++)
            {
                if(cave[y][x] != 0)
                    continue;
                
                var ox = x % offsetX;
                var kx = x / offsetX;

                var value = cave[oy][ox] + ky + kx;
                if (value > 9)
                    value %= 9;
                
                cave[y][x] = (byte)value;
            }
        }
        
        var grid = new Grid2D<byte>(cave);
        
        // for (var y = 0; y < grid.Height; y++)
        // {
        //     for (var x = 0; x < grid.Length; x++)
        //         Console.Write(grid[y, x]);
        //
        //     Console.WriteLine();
        // }

        var dest = new Position2D(grid.Length - 1, grid.Height - 1);

        return FindPathWithLowestRisk(grid, dest);
    }

    private static int FindPathWithLowestRisk(Grid2D<byte> grid, Position2D dest)
    {
        var start = new PathRisk(new Position2D(0, 0), 0);
        var queue = new PriorityQueue<PathRisk, int>();
        var visited = new List<PathRisk>();

        var risks = new Grid2D<int>(ArrayHelper.InitMap(grid.Length, grid.Height, int.MaxValue));
        
        queue.Enqueue(start, 0);

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();

            if (curr.Position == dest)
                return curr.Risk;

            if(visited.Contains(curr))
                continue;
            
            visited.Add(curr);
            
            var nextSteps = curr.Position.GetBasicDirections();
            foreach (var nextStep in nextSteps)
            {
                if(!grid.IsValid(nextStep))
                    continue;
                var nextRisk = curr.Risk + grid[nextStep];
                
                if(risks[nextStep] <= nextRisk)
                    continue;
                risks[nextStep] = nextRisk;
                queue.Enqueue(new PathRisk(nextStep, nextRisk), nextRisk);
            }
        }

        return -1;
    }

    private record PathRisk(Position2D Position, int Risk);
}