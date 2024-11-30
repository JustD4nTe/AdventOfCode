using AoC.Shared;

namespace AoC2023.Day9;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
                           .Select(x => x.Split(" ")
                                         .Select(int.Parse))
                           .ToArray();

        var triangle = new List<List<int>>();
        var sumOfNextHistoryValue = 0;

        foreach (var line in rawInput)
        {
            triangle.Add([.. line]);

            CreateTriangle(triangle);
            FillHistoricLeftSideOfTriangle(triangle);

            sumOfNextHistoryValue += triangle[0][0];
            triangle.Clear();
        }

        return sumOfNextHistoryValue;
    }

    private static void CreateTriangle(List<List<int>> triangle)
    {
        var i = 0;
        do
        {
            var newLine = new List<int>();

            for (var j = 0; j < triangle[i].Count - 1; j++)
            {
                newLine.Add(triangle[i][j + 1] - triangle[i][j]);
            }

            triangle.Add(newLine);
            i++;
        } while (triangle[^1].Any(x => x != 0));
    }

    private static void FillHistoricLeftSideOfTriangle(List<List<int>> triangle)
    {
        triangle[^1].Insert(0, 0);

        for (var i = triangle.Count - 2; i >= 0; i--)
        {
            triangle[i].Insert(0, triangle[i][0] - triangle[i + 1][0]);
        }
    }
}