using System.Linq;

namespace AoC2022.Day8;

internal static class PartOne
{
    public static long Solution()
    {
        var input = File.ReadAllLines("Day8/input.txt")
                        .Select(x => x.ToCharArray()
                                      .Select(y => int.Parse(y.ToString()))
                                      .ToArray())
                        .ToArray();

        var visibleTreeCounter = input.Length * 2 + input[0].Length * 2 - 4;

        for (var i = 1; i < input.Length - 1; i++)
        {
            for (var j = 1; j < input[i].Length - 1; j++)
            {
                var currTree = input[i][j];

                var isVisible = true;

                // up
                for (var k = 1; k <= i; k++)
                {
                    if (input[i - k][j] >= currTree)
                    {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible)
                {
                    visibleTreeCounter++;
                    continue;
                }

                isVisible = true;

                // down
                for (var k = 1; k < input.Length - i; k++)
                {
                    if (input[i + k][j] >= currTree)
                    {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible)
                {
                    visibleTreeCounter++;
                    continue;
                }

                isVisible = true;

                // left
                for (var k = 1; k <= j; k++)
                {
                    if (input[i][j - k] >= currTree)
                    {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible)
                {
                    visibleTreeCounter++;
                    continue;
                }

                isVisible = true;

                // right
                for (var k = 1; k < input[i].Length - j; k++)
                {
                    if (input[i][j + k] >= currTree)
                    {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible)
                    visibleTreeCounter++;
            }
        }

        return visibleTreeCounter;
    }
}