using AoC.Shared;
using System.Text;

namespace AoC2025.Day06;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var mathWorksheet = File.ReadAllLines(Input).ToArray();

        var grandTotal = 0L;

        var i = mathWorksheet[0].Length - 1;
        var strBuilder = new StringBuilder();
        do
        {
            var numbers = new List<long>();
            char[] numberBuffer;
            do
            {
                strBuilder.Clear();

                numberBuffer = [.. mathWorksheet.Select(x => x[i])];
                
                // get number in column
                for (var j = 0; j < numberBuffer.Length - 1; j++)
                    strBuilder.Append(numberBuffer[j]);
                
                numbers.Add(long.Parse(strBuilder.ToString()));
                
                i--;
            } while (numberBuffer[^1] == ' '); // last number will contain operation symbol

            grandTotal += numberBuffer[^1] switch
            {
                '*' => Multiply(numbers),
                '+' => numbers.Sum(),
                _ => throw new Exception()
            };

            i--;
        } while (i >= 0);

        return grandTotal;
    }

    private static long Multiply(List<long> v)
    {
        var result = 1L;

        for (var i = 0; i < v.Count; i++)
            result *= v[i];

        return result;
    }
}