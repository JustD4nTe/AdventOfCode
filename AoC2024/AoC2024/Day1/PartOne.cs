using AoC.Shared;

namespace AoC2024.Day1;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Split("   "))
            .ToArray();

        var left = rawInput.Select(x => int.Parse(x[0])).OrderBy(x => x);
        var right = rawInput.Select(x => int.Parse(x[1])).OrderBy(x => x);
        
        return left.Zip(right).Sum(x => Math.Abs(x.First - x.Second));
    }
}