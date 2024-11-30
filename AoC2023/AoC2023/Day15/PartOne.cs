using AoC.Shared;

namespace AoC2023.Day15;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        return File.ReadAllLines(Input)[0]
                   .Split(",")
                   .Sum(x => HashAlgorithm(x.ToCharArray()));
    }

    private static int HashAlgorithm(char[] str)
    {
        var currValue = 0;

        for (var i = 0; i < str.Length; i++)
        {
            currValue += str[i];
            currValue *= 17;
            currValue %= 256;
        }

        return currValue;
    }
}