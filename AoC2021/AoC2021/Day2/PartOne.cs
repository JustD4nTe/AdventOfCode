using AoC.Shared;

namespace AoC2021.Day2;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var input = File.ReadAllLines(Input).ToArray();

        var hPos = 0;
        var depth = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var buff = input[i].Split(" ");
            var value = int.Parse(buff[1]);
            switch (buff[0])
            {
                case "forward":
                    hPos += value;
                    break;
                case "down":
                    depth += value;
                    break;
                case "up":
                    depth -= value;
                    break;
            }
        }

        return hPos * depth;
    }
}