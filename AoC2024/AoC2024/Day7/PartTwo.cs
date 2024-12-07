using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day7;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.Split(": ")).ToArray();
        var expectedResults = rawInput.Select(x => ulong.Parse(x[0])).ToArray();
        var numbers = rawInput.Select(x => x[1].Split(" ").ToArray()).ToArray();

        ulong sum = 0;
        for (var i = 0; i < expectedResults.Length; i++)
        {
            string[] possibleOperations = ["+", "*", "||"];
            var perm = GetPermutation(possibleOperations, numbers[i].Length - 1);

            for (var j = 0; j < perm.Length; j++)
            {
                var result = ulong.Parse(numbers[i][0]);

                for (var z = 0; z < perm[j].Length; z++)
                {
                    if (perm[j][z] == "+")
                        result += ulong.Parse(numbers[i][z + 1]);
                    else if (perm[j][z] == "*")
                        result *= ulong.Parse(numbers[i][z + 1]);
                    else if(perm[j][z] == "||")
                        result = ulong.Parse(result + numbers[i][z + 1]);
                }

                if (result == expectedResults[i])
                {
                    sum += expectedResults[i];
                    break;
                }
            }
        }

        return (long)sum;
    }

    private static T[][] GetPermutation<T>(T[] possibleValues, int n)
    {
        if (n == 1)
            return possibleValues.Select(x => new[] { x }).ToArray();

        var numberOfPermutations = (int)Math.Pow(possibleValues.Length, n);
        var result = new T[numberOfPermutations][];

        for (var i = 0; i < numberOfPermutations; i++)
            result[i] = new T[n];

        var splitCount = numberOfPermutations;
        for (var i = 0; i < n; i++)
        {
            splitCount /= possibleValues.Length;

            for (int j = 0, k = 0; j < numberOfPermutations; j += splitCount, k++)
            {
                var operation = possibleValues[k % possibleValues.Length];

                for (var z = 0; z < splitCount; z++)
                    result[z + j][i] = operation;
            }
        }

        return result;
    }
}