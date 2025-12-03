using AoC.Shared;

namespace AoC2025.Day3;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var banks = File.ReadAllLines(Input)
            .Select(x => x.ToCharArray())
            .ToArray();

        var sumOfMaximumJoltage = 0L;

        foreach (var bank in banks)
        {
            var batteries = new List<string>();

            var max = bank[..^11].Max();
            batteries.Add(max.ToString());

            var indexOfMax = bank.IndexOf(max);
            var localBank = bank[(indexOfMax + 1)..].AsSpan();

            for (var i = 10; i > 0; i--)
            {
                max = SpanMax(localBank[..^i]);
                batteries.Add(max.ToString());
                indexOfMax = localBank.IndexOf(max);
                localBank = localBank[(indexOfMax + 1)..];
            }

            batteries.Add(SpanMax(localBank).ToString());
            sumOfMaximumJoltage += long.Parse(string.Join("", batteries));
        }

        return sumOfMaximumJoltage;
    }

    private static char SpanMax(Span<char> input)
    {
        var max = input[0];
        for (var i = 1; i < input.Length; i++)
        {
            if (max < input[i])
                max = input[i];
        }
        return max;
    }
}