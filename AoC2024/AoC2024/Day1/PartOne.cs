using AoC.Shared;

namespace AoC2024.Day1;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Split("   "));

        var left = rawInput.Select(x => x[0]).ToArray();
        var right = rawInput.Select(x => x[1]).ToArray();

        Array.Sort(left);
        Array.Sort(right);

        var sum = 0;
        for (var i = 0; i < left.Length; i++)
        {
            sum += Math.Abs(int.Parse(left[i]) - int.Parse(right[i]));
        }

        return sum;
    }
}