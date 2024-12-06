using AoC.Shared;

namespace AoC2024.Day5;

public class PartTwo(string input) : Solution(input)
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

        var updates = rawInput[1].Split("\n").Select(x => x.Split(",").Select(int.Parse).ToList()).ToArray();

        var sum = 0;
        foreach (var update in updates)
        {
            var isUpdateOrderFixed = false;
            for (var i = 1; i < update.Count; i++)
            {
                if (!pageOrderingRules.TryGetValue(update[i], out var expectedBefore))
                    continue;

                var updateSpanSlice = update[..i];

                for (var j = 0; j < expectedBefore.Count; j++)
                {
                    if (updateSpanSlice.Contains(expectedBefore[j]))
                    {
                        isUpdateOrderFixed = true;
                        var index = update.IndexOf(expectedBefore[j]);
                        update.RemoveAt(index);
                        update.Insert(i, expectedBefore[j]);
                        i--; // go again through list after fix
                    }
                }
            }

            if (isUpdateOrderFixed)
                sum += update[update.Count / 2];
        }

        return sum;
    }
}