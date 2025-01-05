using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day11;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Select(y => int.Parse(y.ToString()))
                .ToArray())
            .ToArray();

        var grid = new Grid2D<int>(rawInput);

        var flashedCounter = 0L;

        for (var i = 0; i < 100; i++)
        {
            var flashed = new Queue<Position>();
            foreach (var p in grid.GoThroughGrid())
            {
                grid[p]++;
                if (grid[p] > 9)
                    flashed.Enqueue(p);
            }

            while (flashed.Count > 0)
            {
                var curr = flashed.Dequeue();

                if (grid[curr] <= 9)
                    continue;
                
                foreach (var next in curr.Get8Directions())
                {
                    if (grid.IsValid(next) && grid[next] <= 9)
                    {
                        grid[next]++;
                        
                        if(flashed.Contains(next))
                            continue;
                        
                        flashed.Enqueue(next);
                    }
                }
            }

            foreach (var p in grid.GoThroughGrid())
            {
                if (grid[p] > 9)
                {
                    flashedCounter++;
                    grid[p] = 0;
                }
            }
        }

        return flashedCounter;
    }
}