using AoC.Shared;

namespace AoC2024.Day7;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.Split(": ")).ToArray();
        var expectedResults = rawInput.Select(x => ulong.Parse(x[0])).ToArray();
        var numbers = rawInput.Select(x => x[1].Split(" ").Select(ulong.Parse).ToArray()).ToArray();
        
        ulong sum = 0;
        for (var i = 0; i < expectedResults.Length; i++)
        {
            char[] possibleOperations = ['+', '*'];
            var perm = GetPermutation(possibleOperations, numbers[i].Length - 1);
            
            for (var j = 0; j < perm.Length; j++)
            {
                var result = numbers[i][0];
                for (var z = 0; z < perm[j].Length; z++)
                {
                    if (perm[j][z] == '+')
                        result += numbers[i][z + 1];
                    else if (perm[j][z] == '*')
                        result *= numbers[i][z + 1];
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

    private static char[][] GetPermutation(char[] possibleOperations, int length)
    {
        if (length == 1)
            return possibleOperations.Select(x => new[] { x }).ToArray();

        var numberOfPermutations = (int)Math.Pow(possibleOperations.Length, length);
        var result = new char[numberOfPermutations][];

        for (var i = 0; i < numberOfPermutations; i++)
            result[i] = new char[length];

        var splitCount = numberOfPermutations;
        for (var i = 0; i < length; i++)
        {
            splitCount /= possibleOperations.Length;

            for (int j = 0, k = 0; j < numberOfPermutations; j += splitCount, k++)
            {
                var operation = possibleOperations[k % possibleOperations.Length];

                for (var z = 0; z < splitCount; z++)
                    result[z + j][i] = operation;
            }
        }
        
        return result;
    }
}