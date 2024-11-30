using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2023.Day6;

public class PartOne(string input): Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        var times = Regex.Replace(rawInput[0][6..], @"\s+\s", " ")
                                    .Trim()
                                    .Split(" ")
                                    .Select(int.Parse)
                                    .ToArray();
        var distances = Regex.Replace(rawInput[1][10..], @"\s+\s", " ")
                                        .Trim()
                                        .Split(" ")
                                        .Select(int.Parse)
                                        .ToArray();

        long result = 1;

        for (var i = 0; i < times.Length; i++)
        {
            var winWayCount = 0;

            for (var speed = 0; speed < times[i]; speed++)
            {
                var distance = (times[i] - speed) * speed;

                if (distance > distances[i])
                    winWayCount++;
            }

            result *= winWayCount;
        }

        return result;
    }
}