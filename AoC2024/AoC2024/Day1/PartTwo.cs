using AoC.Shared;

namespace AoC2024.Day1;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Split("   "))
            .ToArray();

        var right = rawInput.Select(x => x[1]) .ToArray();

        var rightOccurrence = new Dictionary<string, int>();

        for (var i = 0; i < right.Length; i++)
        {
            if (rightOccurrence.ContainsKey(right[i]))
            {
                rightOccurrence[right[i]]++;
            }
            else
            {
                rightOccurrence[right[i]] = 1;
            }
        }
        
        var sum = 0;
        for (var i = 0; i < rawInput.Length; i++)
        {
            if (rightOccurrence.TryGetValue(rawInput[i][0], out var value))
            {
                sum += int.Parse(rawInput[i][0]) * value;
            }
        }
        return sum;
    }
}