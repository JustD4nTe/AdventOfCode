using AoC.Shared;

namespace AoC2021.Day3;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Select(y => y == '1').ToArray()).ToArray();

        var gammaRate = "";
        var epsilonRate = "";

        var rawInputLength = rawInput.Length / 2;
        for (var i = 0; i < rawInput[0].Length; i++)
        {
            if (rawInput.Count(x => x[i]) > rawInputLength)
            {
                gammaRate += "1";
                epsilonRate += "0";
            }
            else
            {
                gammaRate += "0";
                epsilonRate += "1";
            }
        }

        return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
    }
}