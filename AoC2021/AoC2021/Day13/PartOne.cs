using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day13;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n");

        var dots = rawInput[0]
            .Split("\r\n")
            .Select(x => x
                .Split(",")
                .Select(int.Parse)
                .ToArray())
            .Select(x => new Position(x[0], x[1]))
            .ToArray();

        var buff = rawInput[1].Split("\r\n")[0].Split(" ")[^1].Split("=");
        var axis = buff[0];
        var lineNumber = int.Parse(buff[1]);

        if (axis == "x")
        {
            var newDots = new List<Position>();

            foreach (var dot in dots)
            {
                if (dot.X < lineNumber)
                    newDots.Add(dot);
                else
                    newDots.Add(dot with { X = lineNumber - (dot.X - lineNumber) });
            }

            return newDots.Distinct().LongCount();
        }
        else
        {
            var newDots = new List<Position>();

            foreach (var dot in dots)
            {
                if (dot.Y < lineNumber)
                    newDots.Add(dot);
                else
                    newDots.Add(dot with { Y = lineNumber - (dot.Y - lineNumber) });
            }

            return newDots.Distinct().LongCount();
        }
    }
}