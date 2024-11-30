using System.Data;
using AoC.Shared;

namespace AoC2023.Day3;

public class PartOne(string input) : Solution(input)
{
    private readonly List<(int, int)> _coordMatrix =
    [
      (-1,-1),
      (0,-1),
      (1,-1),
      (-1,0),
      (0,0),
      (1,0),
      (-1,1),
      (0,1),
      (1,1),
    ];

    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input)
                           .Split("\n")
                           .Select(x => x.ToCharArray())
                           .ToArray();
        var finalSum = 0;

        for (var y = 0; y < rawInput.Length - 1; y++)
        {
            var number = "";
            for (var x = 0; x < rawInput[0].Length; x++)
            {
                if (!char.IsDigit(rawInput[y][x]))
                {
                    number = "";
                    continue;
                }

                number += rawInput[y][x];
                if (IsAdjacentToSymbol(rawInput, y, x))
                {
                    while (x + 1 < rawInput[y].Length && char.IsDigit(rawInput[y][x + 1]))
                        number += rawInput[y][++x];

                    finalSum += int.Parse(number);
                    number = "";
                }
            }
        }

        return finalSum;
    }

    private bool IsAdjacentToSymbol(char[][] rawInput, int y, int x)
    {
        foreach (var coord in _coordMatrix)
        {
            var yChange = y + coord.Item2;
            var xChange = x + coord.Item1;

            if (yChange < 0 || yChange >= rawInput.Length)
                continue;
            if (xChange < 0 || xChange >= rawInput[yChange].Length)
                continue;

            var buff = rawInput[yChange][xChange];

            if (buff == '.' || char.IsDigit(buff))
                continue;

            return true;
        }

        return false;
    }
}