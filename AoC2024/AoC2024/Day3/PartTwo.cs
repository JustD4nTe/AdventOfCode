using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2024.Day3;

public partial class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var validInstructions = File.ReadAllLines(Input)
            .SelectMany(x => InstructionRegex().Matches(x).Select(y => y.Value));

        var sum = 0;
        var canDo = true;
        foreach (var instruction in validInstructions)
        {
            switch (instruction)
            {
                case "do()":
                    canDo = true;
                    continue;
                case "don't()":
                    canDo = false;
                    continue;
                default:
                {
                    if (canDo)
                    {
                        var numbers = NumberRegex().Matches(instruction).Select(x => int.Parse(x.Value)).ToArray();
                        sum += numbers.First() * numbers.Last();
                    }

                    break;
                }
            }
        }
        
        return sum;
    }

    [GeneratedRegex(@"(mul\([\d]{1,3},[\d]{1,3}\))|(don't\(\))|(do\(\))")]
    private static partial Regex InstructionRegex();
    
    [GeneratedRegex(@"[\d]{1,3}")]
    private static partial Regex NumberRegex();
}