using AoC.Shared;

namespace AoC2024.Day4;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();

        var counter = 0;
        for (var i = 0; i < rawInput.Length; i++)
        {
            for (var j = 0; j < rawInput[0].Length; j++)
            {
                if (rawInput[i][j] != 'X')
                    continue;

                if (j + 3 < rawInput[i].Length)
                {
                    // right - up
                    if (i - 3 >= 0
                        && rawInput[i - 1][j + 1] == 'M'
                        && rawInput[i - 2][j + 2] == 'A'
                        && rawInput[i - 3][j + 3] == 'S')
                        counter++;

                    // right
                    if (rawInput[i][j + 1] == 'M' && rawInput[i][j + 2] == 'A' && rawInput[i][j + 3] == 'S')
                        counter++;

                    // right - down
                    if (i + 3 < rawInput.Length
                        && rawInput[i + 1][j + 1] == 'M'
                        && rawInput[i + 2][j + 2] == 'A'
                        && rawInput[i + 3][j + 3] == 'S')
                        counter++;
                }

                if (j - 3 >= 0)
                {
                    // left - up
                    if (i - 3 >= 0
                        && rawInput[i - 1][j - 1] == 'M'
                        && rawInput[i - 2][j - 2] == 'A'
                        && rawInput[i - 3][j - 3] == 'S')
                        counter++;

                    // left
                    if (rawInput[i][j - 1] == 'M' && rawInput[i][j - 2] == 'A' && rawInput[i][j - 3] == 'S')
                        counter++;

                    // left - down
                    if (i + 3 < rawInput.Length
                        && rawInput[i + 1][j - 1] == 'M'
                        && rawInput[i + 2][j - 2] == 'A'
                        && rawInput[i + 3][j - 3] == 'S')
                        counter++;
                }

                // up
                if (i - 3 >= 0
                    && rawInput[i - 1][j] == 'M'
                    && rawInput[i - 2][j] == 'A'
                    && rawInput[i - 3][j] == 'S')
                    counter++;

                // down
                if (i + 3 < rawInput.Length
                    && rawInput[i + 1][j] == 'M'
                    && rawInput[i + 2][j] == 'A'
                    && rawInput[i + 3][j] == 'S')
                    counter++;
            }
        }

        return counter;
    }
}