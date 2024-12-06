using AoC.Shared;

namespace AoC2024.Day5;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\n\n");
        var buff = rawInput[0].Split("\n")
            .Select(x => x
                .Split("|")
                .Select(int.Parse).ToArray())
            .ToArray();
        var pageOrderingRules = new Dictionary<int, List<int>>();
        foreach (var temp in buff)
        {
            var key = temp[0];
            var value = temp[1];
            if (pageOrderingRules.TryGetValue(key, out _))
                pageOrderingRules[key].Add(value);
            else
                pageOrderingRules[key] = [value];
        }

        var updates = rawInput[1].Split("\n").Select(x => x.Split(",").Select(int.Parse).ToArray()).ToArray();

        var sum = 0;
        foreach (var update in updates)
        {
            var isValidUpdate = true;

            for (var i = 1; i < update.Length; i++)
            {
                if (!pageOrderingRules.TryGetValue(update[i], out var expectedBefore))
                    continue;

                var updateSpanSlice = update.AsSpan()[..i];

                for (var j = 0; j < expectedBefore.Count; j++)
                {
                    if (updateSpanSlice.Contains(expectedBefore[j]))
                    {
                        isValidUpdate = false;
                        break;
                    }
                }
            }

            if (isValidUpdate)
                sum += update[update.Length / 2];
        }

        return sum;
    }
}