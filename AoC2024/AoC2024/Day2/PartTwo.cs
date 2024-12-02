using AoC.Shared;

namespace AoC2024.Day2;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var reports = File.ReadAllLines(Input)
            .Select(x => x.Split(" ").Select(int.Parse).ToArray())
            .ToArray();

        var safeCounter = 0;

        foreach (var report in reports)
        {
            if (CheckReport(report))
            {
                safeCounter++;
                continue;
            }

            for (var i = 0; i < report.Length; i++)
            {
                var temp = report.ToList();
                temp.RemoveAt(i);

                if (CheckReport(temp.ToArray()))
                {
                    safeCounter++;
                    break;
                }
            }
        }

        return safeCounter;
    }

    private static bool CheckReport(int[] report)
    {
        var diff = new List<int>();
        for (var i = 0; i < report.Length - 1; i++)
        {
            diff.Add(report[i] - report[i + 1]);
        }

        if (diff.All(x => x < 0))
        {
            return diff.All(x => x is <= -1 and >= -3);
        }
        else if (diff.All(x => x > 0))
        {
            return diff.All(x => x is >= 1 and <= 3);
        }
        
        return false;
    }
    
    private static bool IsSafe(int diff, bool isAsc)
        => IsLevelDiffCorrect(diff) && ((isAsc && diff > 0) || (!isAsc && diff < 0));

    private static bool IsLevelDiffCorrect(int diff)
        => Math.Abs(diff) is >= 1 and <= 3;
}