using AoC.Shared;

namespace AoC2025.Day03;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var banks = File.ReadAllLines(Input)
            .Select(x => x.ToCharArray())
            .ToArray();

        var sumOfMaximumJoltage = 0;

        foreach (var bank in banks)
        {
            var firstMax = bank[..^1].Max();
            var indexOfMax = bank.IndexOf(firstMax);

            var afterFirstMax = bank[(indexOfMax + 1)..];
            var maxAfterFirstMax = afterFirstMax.Max();

            var largestJoltage = firstMax.ToString() + maxAfterFirstMax.ToString();
            sumOfMaximumJoltage += int.Parse(largestJoltage);
        }

        return sumOfMaximumJoltage;
    }
}