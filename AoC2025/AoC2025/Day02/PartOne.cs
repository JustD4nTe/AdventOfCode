using AoC.Shared;

namespace AoC2025.Day02;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input)
            .Split(",");

        var invalidIdsSum = 0L;

        foreach (var line in rawInput)
        {
            var temp = line.Split("-");
            var first = long.Parse(temp[0]);
            var second = long.Parse(temp[1]);

            for (var i = first; i <= second; i++)
            {
                if (IsPalindrome(i.ToString()))
                    invalidIdsSum += i;
            }
        }

        return invalidIdsSum;
    }

    private static bool IsPalindrome(string v)
    {
        if (v.Length % 2 == 1)
            return false;

        var half = v.Length / 2;
        return v[..half] == v[half..];
    }
}