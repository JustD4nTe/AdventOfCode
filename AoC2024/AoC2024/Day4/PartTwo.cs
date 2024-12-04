using AoC.Shared;

namespace AoC2024.Day4;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();

        var counter = 0;
        for (var i = 1; i < rawInput.Length - 1; i++)
        {
            for (var j = 1; j < rawInput[0].Length - 1; j++)
            {
                if (rawInput[i][j] != 'A')
                    continue;
                
                if(((rawInput[i + 1][j - 1] == 'M' && rawInput[i - 1][j + 1] == 'S')
                   || (rawInput[i + 1][j - 1] == 'S' && rawInput[i - 1][j + 1] == 'M'))
                   && ((rawInput[i - 1][j - 1] == 'M' && rawInput[i + 1][j + 1] == 'S')
                      || (rawInput[i - 1][j - 1] == 'S' && rawInput[i + 1][j + 1] == 'M')))
                    counter++;
            }
        }

        return counter;
    }
}