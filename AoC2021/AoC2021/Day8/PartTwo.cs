using System.Text;
using AoC.Shared;
using AoC.Shared.Helpers;

namespace AoC2021.Day8;

public class PartTwo(string input) : Solution(input)
{
    //  0000
    // 1    2
    // 1    2
    //  3333
    // 4    5
    // 4    5
    //  6666
    private readonly byte[][] _segmentDisplay =
    [
        [0, 1, 2, 4, 5, 6], // 0
        [2, 5], // 1
        [0, 2, 3, 4, 6], // 2
        [0, 2, 3, 5, 6], // 3
        [1, 2, 3, 5], // 4
        [0, 1, 3, 5, 6], // 5
        [0, 1, 3, 4, 5, 6], // 6
        [0, 2, 5], // 7
        [0, 1, 2, 3, 4, 5, 6], // 8
        [0, 1, 2, 3, 5, 6] // 9
    ];

    public override long Solve()
    {
        var displays = File.ReadAllLines(Input)
            .Select(x => x
                .Split(" | ")
                .Select(y => y.Split(" ").ToArray())
                .ToArray())
            .ToArray();


        var allPossibilities = ArrayHelper.GetPermutations<byte>([0, 1, 2, 3, 4, 5, 6], 7);
        var sum = 0L;

        foreach (var display in displays)
        {
            var inputs = display[0].Select(x => x.ToCharArray()).ToArray();
            var outputs = display[1].Select(x => x.ToCharArray()).ToArray();

            foreach (var possibility in allPossibilities)
            {
                var prop = new Dictionary<char, byte>()
                {
                    ['a'] = possibility[0],
                    ['b'] = possibility[1],
                    ['c'] = possibility[2],
                    ['d'] = possibility[3],
                    ['e'] = possibility[4],
                    ['f'] = possibility[5],
                    ['g'] = possibility[6],
                };

                var isValid = inputs.All(x =>
                    _segmentDisplay.Any(y => y.SequenceEqual(x.Select(z => prop[z]).Order())));

                if (!isValid)
                    continue;

                var value = 0;
                foreach (var output in outputs)
                {
                    var translatedOutput = output.Select(x => prop[x]).Order().ToArray();
                    for (var i = 0; i < _segmentDisplay.Length; i++)
                    {
                        if (_segmentDisplay[i].SequenceEqual(translatedOutput))
                        {
                            value *= 10;
                            value += i;
                            break;
                        }
                    }
                }

                sum += value;
                break;
            }
        }

        return sum;
    }
}