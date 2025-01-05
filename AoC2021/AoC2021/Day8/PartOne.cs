using AoC.Shared;

namespace AoC2021.Day8;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        return File.ReadAllLines(Input)
            .Select(x => x
                .Split("|")[1]
                .Split(" "))
        .SelectMany(x => x)
        .Count(x => x.Length is 2 or 3 or 4 or 7);
    }
}