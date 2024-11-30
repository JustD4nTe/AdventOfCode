using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2023.Day6;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        var raceTime = long.Parse(Regex.Replace(rawInput[0][6..], @"\s+\s", ""));
        var raceDistance = long.Parse(Regex.Replace(rawInput[1][10..], @"\s+\s", ""));

        long winWayCount = 0;

        for (long speed = 0; speed < raceTime; speed++)
        {
            var distance = (raceTime - speed) * speed;

            if (distance > raceDistance)
                winWayCount++;
        }

        return winWayCount;
    }
}