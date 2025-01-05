using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day6;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split(",").Select(long.Parse).ToArray();

        var days = new long[9];

        for (var i = 0; i < 9; i++)
            days[i] = rawInput.Count(x => x == i);

        for(var i = 0; i < 80; i++) 
            days[(i + 7) % 9] += days[i % 9];

        return days.Sum();
    }
}