using AoC.Shared;

namespace AoC2024.Day1;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Split("   "))
            .ToArray();

        var right = rawInput.Select(x => x[1]).CountBy(x => x).ToDictionary();

        return rawInput.Sum(x => int.Parse(x[0]) * right.GetValueOrDefault(x[0]));
    }
}