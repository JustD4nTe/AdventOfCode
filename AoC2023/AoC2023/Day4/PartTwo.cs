using AoC.Shared;

namespace AoC2023.Day4;

public class PartTwo(string input) : Solution(input)
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
                                          .ToList())
                           .ToList();

        var scratchcardCounter = new int[rawInput.Count];
        Array.Fill(scratchcardCounter, 1);

        for (var i = 0; i < rawInput.Count; i++)
        {
            var intersectCount = rawInput[i][0].Intersect(rawInput[i][1]).Count();
            for (var j = 1; j <= intersectCount; j++)
            {
                scratchcardCounter[i + j] += scratchcardCounter[i];
            }
        }

        return scratchcardCounter.Sum();
    }
}