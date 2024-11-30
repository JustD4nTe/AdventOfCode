using AoC.Shared;

namespace AoC2023.Day8;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        var instructions = rawInput[0].ToCharArray();

        rawInput = rawInput[2..];

        var map = new Dictionary<string, Node>();

        for (var i = 0; i < rawInput.Length; i++)
        {
            var temp = rawInput[i].Split("=").Select(x => x.Trim()).ToArray();
            var rawNode = temp[1].Split(", ");
            var node = new Node(rawNode[0][1..], rawNode[1][..^1]);

            map[temp[0]] = node;
        }

        var position = "AAA";
        var index = 0;
        var steps = 0;

        do
        {
            if (index >= instructions.Length)
                index = 0;

            position = map[position].GetDirection(instructions[index++]);
            steps++;
        } while (position != "ZZZ");

        return steps;
    }

    private record Node(string Left, string Right)
    {
        public string GetDirection(char direction)
            => direction == 'L' ? Left : Right;
    }
}