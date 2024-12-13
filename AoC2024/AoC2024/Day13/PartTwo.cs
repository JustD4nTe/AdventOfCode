using System.Text;
using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day13;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n").Select(x => x.Split("\r\n"));

        const int aCost = 3, bCost = 1;

        long tokenPayed = 0;

        foreach (var game in rawInput)
        {
            var btnA = Parsexy(game[0]);
            var btnB = Parsexy(game[1]);
            var target = Parsexy(game[2]).Select(x => x + 10_000_000_000_000).ToArray();
            var w = btnA[0] * btnB[1] - btnA[1] * btnB[0];
            var wa = target[0] * btnB[1] - target[1] * btnB[0];
            var wb = btnA[0] * target[1] - btnA[1] * target[0];

            if (w == 0 && (wa == 0 || wb == 0))
                continue;

            var a = wa / w;
            var b = wb / w;

            if (a * btnA[0] + b * btnB[0] == target[0] && a * btnA[1] + b * btnB[1] == target[1])
            {
                tokenPayed += a * aCost + b * bCost;
            }
        }


        return tokenPayed;
    }

    private static long[] Parsexy(string str) // :3
        => str.Split(": ")[1].Split(", ").Select(x => long.Parse(x[2..])).ToArray();
}