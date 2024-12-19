using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.Helpers;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day19;

public class PartTwo(string input) : Solution(input)
{
    private readonly Dictionary<char, List<string>> _availableTowels = [];

    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var towels = rawInput[0].Split(", ");

        foreach (var towel in towels)
        {
            if (_availableTowels.TryGetValue(towel[0], out var towelList))
                towelList.Add(towel);
            else
                _availableTowels[towel[0]] = [towel];
        }

        var designs = rawInput[1].Split("\r\n").ToArray();

        Func<string, long> checkDesign = null;

        checkDesign = FuncHelpers.Memoize((string design) =>
        {
            if (!_availableTowels.TryGetValue(design[0], out var localTowels))
                return 0;

            long counter = 0;
            
            foreach (var localTowel in localTowels)
            {
                if (!design.StartsWith(localTowel))
                    continue;

                if (localTowel.Length == design.Length)
                    counter++;
                else
                    counter += checkDesign(design[localTowel.Length..]);
            }

            return counter;
        });

        return designs.Sum(checkDesign);
    }
}