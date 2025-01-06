using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day14;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var template = rawInput[0].ToCharArray().ToList();
        var rules = rawInput[1].Split("\r\n").Select(x => x.Split(" -> "))
            .ToDictionary(x => (x[0][0], x[0][1]), x => x[1][0]);

        for (var step = 0; step < 10; step++)
        {
            for (var i = 0; i < template.Count - 1; i++)
            {
                if (rules.TryGetValue((template[i], template[i + 1]), out var value))
                {
                    template.Insert(i + 1, value);
                    i++;
                }
            }
        }

        var temp = template.CountBy(x => x).Select(x => x.Value).Order().ToArray();
        return temp[^1] - temp[0];
    }
}