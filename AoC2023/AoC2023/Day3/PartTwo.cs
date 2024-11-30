using System.Data;
using System.Text;
using AoC.Shared;

namespace AoC2023.Day3;

public class PartTwo(string input) : Solution(input)
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
            for (var x = 0; x < rawInput[0].Length; x++)
            {
                if (rawInput[y][x] != '*')
                    continue;

                finalSum += CalculateGearRatio(rawInput, y, x);
            }
        }

        return finalSum;
    }

    private static int GetNumber(char[][] rawInput, int y, int x)
    {
        StringBuilder number = new();
        number.Append(rawInput[y][x]);

        var postX = x;
        var preX = x;

        while (++postX < rawInput[y].Length && char.IsDigit(rawInput[y][postX]))
            number.Append(rawInput[y][postX]);

        while (--preX >= 0 && char.IsDigit(rawInput[y][preX]))
            number.Insert(0, rawInput[y][preX]);

        return int.Parse(number.ToString());
    }

    private int CalculateGearRatio(char[][] rawInput, int y, int x)
    {
        HashSet<int> gears = [];
        foreach (var coord in _coordMatrix)
        {
            var yChange = y + coord.Item2;
            var xChange = x + coord.Item1;

            if (yChange < 0 || yChange >= rawInput.Length)
                continue;
            if (xChange < 0 || xChange >= rawInput[yChange].Length)
                continue;

            var buff = rawInput[yChange][xChange];

            if (char.IsDigit(buff))
                gears.Add(GetNumber(rawInput, yChange, xChange));
        }

        return gears.Count == 2 ? gears.Aggregate((a, x) => a * x) : 0;
    }
}