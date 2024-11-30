using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2023.Day1;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);
        var sum = 0;
        foreach (var line in rawInput)
        {
            var strNumber = Regex.Replace(line, "[a-zA-Z]", "");
            sum += int.Parse(strNumber[0].ToString() + strNumber[^1]);
        }

        return sum;
    }
}