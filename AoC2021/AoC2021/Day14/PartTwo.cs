using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day14;

public class PartTwo(string input) : Solution(input)
{
    private static Dictionary<Pair, char> _rules = new();

    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var template = rawInput[0].ToCharArray().ToList();

        _rules = rawInput[1]
            .Split("\r\n")
            .Select(x => x.Split(" -> "))
            .ToDictionary(x => new Pair(x[0][0], x[0][1]), x => x[1][0]);

        Func<int, Pair, Dictionary<char, ulong>> getPairRuleResult = null!;

        getPairRuleResult = FuncHelpers.Memoize((int step, Pair pair) =>
        {
            var result = new Dictionary<char, ulong>();
            var value = _rules[pair];
            if (step == 40)
            {
                result[value] = 1;

                if (!result.TryAdd(pair.Left, 1))
                    result[pair.Left] += 1;

                if (!result.TryAdd(pair.Right, 1))
                    result[pair.Right] += 1;

                return result;
            }

            var first = getPairRuleResult(step + 1, pair with { Right = value });
            foreach (var (key, count) in first)
            {
                if (!result.TryAdd(key, count))
                    result[key] += count;
            }

            var second = getPairRuleResult(step + 1, pair with { Left = value });
            foreach (var (key, count) in second)
            {
                if (!result.TryAdd(key, count))
                    result[key] += count;
            }

            result[value]--;

            return result;
        });

        var result = new Dictionary<char, ulong>();

        for (var i = 0; i < template.Count - 1; i++)
        {
            var pair = getPairRuleResult(1, new Pair(template[i], template[i + 1]));
            foreach (var (key, count) in pair)
            {
                if (!result.TryAdd(key, count))
                    result[key] += count;
            }
        }

        for (var i = 1; i < template.Count - 1; i++)
            result[template[i]]--;

        var temp = result.Select(x => x.Value).Order().ToArray();
        return (long)temp[^1] - (long)temp[0];
    }

    private record Pair(char Left, char Right);
}