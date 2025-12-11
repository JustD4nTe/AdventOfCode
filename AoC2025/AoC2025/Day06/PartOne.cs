using AoC.Shared;

namespace AoC2025.Day06;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var mathWorksheet = File.ReadAllLines(Input)
            .Select(x => x.Split(" ")
                          .Where(x => x != "")
                          .Select(x => x.Trim())
                          .ToArray())
            .ToArray();

        var grandTotal = 0L;

        for (var i = 0; i < mathWorksheet[0].Length; i++)
        {
            var numbers = mathWorksheet[..^1].Select(x => long.Parse(x[i])).ToArray();
            grandTotal += mathWorksheet[^1][i] switch
            {
                "*" => Multiply(numbers),
                "+" => numbers.Sum(),
                _ => throw new Exception()
            };
        }

        return grandTotal;
    }

    private static long Multiply(long[] v)
    {
        var result = 1L;
        
        for (var i = 0; i < v.Length; i++)
            result *= v[i];

        return result;
    }
}