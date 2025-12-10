using AoC.Shared;
using AoC.Shared.Helpers;

namespace AoC2025.Day10;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var raw = File.ReadAllLines(Input)
            .Select(x => x.Split(" ").ToArray())
            .ToArray();

        var lights = raw.Select(x => x[0][1..^1].Select(x => x == '#').ToArray()).ToArray();
        var buttons = raw.Select(x => x[1..^1].Select(y => y[1..^1].Split(",")
                                                                   .Select(int.Parse)
                                                                   .ToArray())
                                              .ToList())
                         .ToArray();
        
        var result = 0;

        for (var i = 0; i < raw.Length; i++)
        {
            var currState = new bool[lights[i].Length];
            var currButtons = buttons[i].Select(x => GetButtonsLighsToggles(x, currState.Length)).ToArray();

            if (currButtons.Any(x => x.SequenceEqual(lights[i])))
            {
                result += 1;
                continue;
            }

            for (var j = 2; j <= currButtons.Length; j++)
            {
                var perms = ArrayHelper.GetPermutations(currButtons, j);

                if (perms.Select(ToggleLights).Any(x => x.SequenceEqual(lights[i])))
                {
                    result += j;
                    break;
                }
            }
        }

        return result;
    }

    private static bool[] ToggleLights(bool[][] buttons)
    {
        var results = new bool[buttons[0].Length];
        
        for (var i = 0; i < buttons[0].Length; i++)
        {
            results[i] = buttons.Select(x => x[i]).Aggregate((x, a) => a ^ x);
        }

        return results;
    }

    private static bool[] GetButtonsLighsToggles(int[] buttons, int lightsCount)
    {
        var lights = new bool[lightsCount];
        
        for (var i = 0; i < lightsCount; i++)
        {
            lights[i] = buttons.Contains(i);
        }

        return lights;
    }
}