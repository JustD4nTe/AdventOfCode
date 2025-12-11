using AoC.Shared;
using System.Collections.Immutable;

namespace AoC2025.Day09;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var redTilesPositions = File.ReadAllLines(Input)
            .Select(x => x.Split(",").Select(int.Parse).ToArray())
            .ToImmutableArray();

        var maxSize = 0L;

        for (var i = 0; i < redTilesPositions.Length - 1; i++)
        {
            for (var j = i + 1; j < redTilesPositions.Length; j++)
            {
                long xL = GetTileLength(redTilesPositions[i][0], redTilesPositions[j][0]);
                long yL = GetTileLength(redTilesPositions[i][1], redTilesPositions[j][1]);

                var square = xL * yL;

                if (maxSize < square)
                    maxSize = square;
            }
        }

        return maxSize;
    }

    private static long GetTileLength(int t1, int t2) 
        => t1 > t2 ? t1 - t2 + 1 : t2 - t1 + 1;
}