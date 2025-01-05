using AoC.Shared;

namespace AoC2021.Day3;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(x => x.Select(y => y == '1').ToArray()).ToArray();

        var oxygenCopy = rawInput.Select(x => x.ToList()).ToList();
        var co2Copy = rawInput.Select(x => x.ToList()).ToList();

        for (var i = 0; i < rawInput[0].Length; i++)
        {
            var trueCountOxygen = oxygenCopy.Count(x => x[i]);
            var trueCountCo2 = co2Copy.Count(x => x[i]);

            if (oxygenCopy.Count > 1)
            {
                if (trueCountOxygen >= oxygenCopy.Count / 2.0)
                    oxygenCopy.RemoveAll(x => !x[i]);
                else
                    oxygenCopy.RemoveAll(x => x[i]);
            }

            if (co2Copy.Count > 1)
            {
                if (trueCountCo2 >= co2Copy.Count / 2.0)
                    co2Copy.RemoveAll(x => x[i]);
                else
                    co2Copy.RemoveAll(x => !x[i]);
            }
        }

        var oxygen = Convert.ToInt32(string.Join("", oxygenCopy[0].Select(x => x ? "1" : "0")), 2);
        var co2 = Convert.ToInt32(string.Join("", co2Copy[0].Select(x => x ? "1" : "0")), 2);

        return oxygen * co2;
    }
}