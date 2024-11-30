using AoC.Shared;

namespace AoC2023.Day4;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
                           .Select(x => x.Split(":")[1]
                                         .Split("|")
                                         .Select(y => y.Trim()
                                                       .Replace("  ", " ")
                                                       .Split(" ")
                                                       .Select(int.Parse))
                                          .ToList());

        var result = 0;

        foreach (var line in rawInput)
        {
            var intersectCount = line[0].Intersect(line[1]).Count();
            result += (int)Math.Pow(2, intersectCount - 1);
        }

        return result;
    }
}