using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2024.Day3;

public partial class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        return File.ReadAllLines(Input)
            .SelectMany(x => MulRegex()
                .Matches(x)
                .Select(y => NumberRegex()
                    .Matches(y.Value)
                    .Select(z => int.Parse(z.Value))
                    .ToArray()))
            .Sum(x => x.First() * x.Last());
    }

    [GeneratedRegex(@"mul\([\d]{1,3},[\d]{1,3}\)")]
    private static partial Regex MulRegex();
    
    [GeneratedRegex(@"[\d]{1,3}")]
    private static partial Regex NumberRegex();
}