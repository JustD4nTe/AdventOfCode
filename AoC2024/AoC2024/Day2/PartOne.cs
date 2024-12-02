using AoC.Shared;

namespace AoC2024.Day2;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var reports = File.ReadAllLines(Input)
            .Select(x => x.Split(" ").Select(int.Parse).ToArray())
            .ToArray();

        var safeCounter = 0;

        foreach (var report in reports)
        {
            var diff = report[0] - report[1];
            if (!IsSafe(diff))
                continue;

            var isAsc = report[0] - report[1] > 0;


            var isSafe = true;

            for (var j = 1; j < report.Length - 1; j++)
            {
                diff = report[j] - report[j + 1];

                if (!IsSafe(diff))
                {
                    isSafe = false;
                    break;
                }

                switch (isAsc)
                {
                    case true when diff > 0:
                    case false when diff < 0:
                        continue;
                    default:
                        isSafe = false;
                        break;
                }
            }

            if (isSafe)
                safeCounter++;
        }

        return safeCounter;
    }

    private static bool IsSafe(int diff) => Math.Abs(diff) is >= 1 and <= 3;
}