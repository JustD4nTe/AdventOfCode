using AoC.Shared;

namespace AoC2025.Day12;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var raw = File.ReadAllLines(Input)
            .Skip(30) // don't need present's shapes
            .ToArray();

        var result = 0L;
        
        foreach (var item in raw)
        {
            var tmp = item.Split(": ");
            var region = tmp[0].Split("x");

            var size = int.Parse(region[0]) * int.Parse(region[1]);
            var presentsCount = tmp[1].Split(" ").Sum(int.Parse);

            if (size >= presentsCount * 9)
                result++;
        }

        return result;
    }
}