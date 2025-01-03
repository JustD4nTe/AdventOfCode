using System.Text;
using System.Text.RegularExpressions;
using AoC.Shared;

namespace AoC2023.Day12;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
                           .Select(x => x.Split(" "));

        var sumOfDifferentArragements = 0;

        foreach (var line in rawInput)
        {
            var field = line[0];
            var groupArragment = line[1].Split(",").Select(int.Parse);

            var knownSpringCount = field.Count(x => x == '#');
            var unkownSpringCount = field.Count(x => x == '?');
            var minNumberOfSprings = groupArragment.Sum();
            var minNumberOfUnkownSprings = minNumberOfSprings - knownSpringCount;

            var template = new bool[unkownSpringCount];
            Array.Fill(template, true, 0, minNumberOfUnkownSprings);

            var counter = GetInt(template.Reverse());

            var localDiffCounter = 0;

            do
            {
                template = GetBin(counter, unkownSpringCount);
                if (template.Count(x => x) != minNumberOfUnkownSprings)
                {
                    counter++;
                    continue;
                }
                var fieldPropositionBuilder = new StringBuilder();

                for (int i = 0, j = 0; i < field.Length; i++)
                {
                    if (field[i] != '?')
                    {
                        fieldPropositionBuilder.Append(field[i]);
                        continue;
                    }

                    if (template[j])
                        fieldPropositionBuilder.Append('#');
                    else
                        fieldPropositionBuilder.Append('.');

                    j++;
                }

                var fieldProposition = fieldPropositionBuilder.ToString();

                var proposition = Regex.Replace(fieldProposition, "[.]+", ".")
                                       .Split(".")
                                       .Select(x => x.Length)
                                       .Where(x => x != 0);

                if (groupArragment.SequenceEqual(proposition))
                    localDiffCounter++;

                counter++;
            } while (template.Any(x => !x));

            sumOfDifferentArragements += localDiffCounter;
        }

        return sumOfDifferentArragements;
    }

    private static bool[] GetBin(int value, int minSize)
    {
        var buff = Convert.ToString(value, 2);

        if (buff.Length < minSize)
            buff = new string('0', minSize - buff.Length) + buff;

        return buff.Select(s => s.Equals('1'))
                   .ToArray();
    }

    private static int GetInt(IEnumerable<bool> value)
        => Convert.ToInt32(string.Join("", value.Select(x => x ? '1' : '0')), 2);
}