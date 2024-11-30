using AoC.Shared;

namespace AoC2023.Day8;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        var instructions = rawInput[0].ToCharArray();

        var map = new Dictionary<string, Node>();

        for (var i = 2; i < rawInput.Length; i++)
        {
            var temp = rawInput[i].Split("=").Select(x => x.Trim()).ToArray();
            var rawNode = temp[1][1..^1].Split(", ");

            map[temp[0]] = new Node(rawNode[0], rawNode[1]);
        }

        var currNodes = map.Keys.Where(x => x.EndsWith('A')).ToArray();
        var minSteps = new List<long>();
        var index = 0;
        var steps = 0;

        do
        {
            if (index >= instructions.Length)
                index = 0;

            for (var i = 0; i < currNodes.Length; i++)
            {
                currNodes[i] = map[currNodes[i]].GetDirection(instructions[index]);
            }

            index++;
            steps++;

            if (currNodes.Any(x => x.EndsWith('Z')))
            {
                currNodes = currNodes.Where(x => !x.EndsWith('Z')).ToArray();
                minSteps.Add(steps);
            }

        } while (currNodes.Length > 0 && !currNodes.All(x => x.EndsWith('Z')));

        return LCM(minSteps.ToArray());
    }

    private record Node(string Left, string Right)
    {
        public string GetDirection(char direction)
            => direction == 'L' ? Left : Right;
    }

    //https://stackoverflow.com/questions/147515/least-common-multiple-for-3-or-more-numbers/29717490#29717490
    private static long LCM(long[] numbers)
        => numbers.Aggregate((a, b) => Math.Abs(a * b) / GCD(a, b));

    private static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0)
                return a;
            
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }
}