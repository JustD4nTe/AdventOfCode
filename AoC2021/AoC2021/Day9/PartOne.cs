using AoC.Shared;

namespace AoC2021.Day9;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var heatmap = File.ReadAllLines(Input)
            .Select(x => x
                .ToCharArray()
                .Select(y =>
                    int.Parse(y.ToString()))
                .ToArray())
            .ToArray();

        var sum = 0L;

        for (var y = 0; y < heatmap.Length; y++)
        {
            for (var x = 0; x < heatmap[y].Length; x++)
            {
                var curr = heatmap[y][x];

                // up
                if (y > 0 && heatmap[y - 1][x] <= curr)
                    continue;
                
                // right
                if (x + 1 < heatmap[y].Length && heatmap[y][x + 1] <= curr)
                    continue;
                
                // down
                if(y + 1 < heatmap.Length && heatmap[y + 1][x] <= curr)
                    continue;
                
                // left
                if(x > 0 && heatmap[y][x - 1] <= curr)
                    continue;

                sum += curr + 1;
            }
        }

        return sum;
    }
}