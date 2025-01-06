using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day15;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var grid = new Grid2D<int>(File.ReadAllLines(Input)
            .Select(x => x
                .ToCharArray().Select(y => int.Parse(y.ToString()))
                .ToArray())
            .ToArray());

        var dest = new Position(grid.Length - 1, grid.Height - 1);

        return FindPathWithLowestRisk(grid, dest);
    }

    private static int FindPathWithLowestRisk(Grid2D<int> grid, Position dest)
    {
        var start = new PathRisk(new Position(0, 0), 0);
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

    private record PathRisk(Position Position, int Risk);
}