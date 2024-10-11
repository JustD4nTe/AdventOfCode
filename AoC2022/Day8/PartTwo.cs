using System.Linq;

namespace AoC2022.Day8;

internal static class PartTwo
{
    public static long Solution()
    {
        var trees = File.ReadAllLines("Day8/input.txt")
                        .Select(x => x.ToCharArray()
                                      .Select(y => int.Parse(y.ToString()))
                                      .ToArray())
                        .ToArray();

        var scienicScores = new List<long>();

        for (var row = 1; row < trees.Length - 1; row++)
        {
            for (var col = 1; col < trees[row].Length - 1; col++)
            {
                var score = CaluclateUpDistance(trees, row, col);
                score *= CaluclateDownDistance(trees, row, col);
                score *= CaluclateLeftDistance(trees, row, col);
                score *= CaluclateRightDistance(trees, row, col);

                scienicScores.Add(score);
            }
        }

        return scienicScores.Max();
    }

    private static int CaluclateUpDistance(int[][] trees, int row, int col)
    {
        var distance = 1;
        for (; distance <= row; distance++)
        {
            if (trees[row - distance][col] >= trees[row][col])
                return distance;
        }   

        return distance - 1;
    }

    private static int CaluclateDownDistance(int[][] trees, int row, int col)
    {
        var distance = 1;
        for (; distance < trees.Length - row; distance++)
        {
            if (trees[row + distance][col] >= trees[row][col])
                return distance;
        }

        return distance - 1;
    }

    private static int CaluclateLeftDistance(int[][] trees, int row, int col)
    {
        var distance = 1;
        for (; distance <= col; distance++)
        {
            if (trees[row][col - distance] >= trees[row][col])
                return distance;
        }

        return distance - 1;
    }

    private static int CaluclateRightDistance(int[][] trees, int row, int col)
    {
        var distance = 1;
        for (; distance < trees[row].Length - col; distance++)
        {
            if (trees[row][col + distance] >= trees[row][col])
                return distance;
        }

        return distance - 1;
    }
}