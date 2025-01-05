using AoC.Shared;

namespace AoC2021.Day1;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var depths = File.ReadAllLines(Input).Select(int.Parse).ToArray();
        var counter = 0;
        for(var i = 2; i < depths.Length - 1; i++)
        {
            if (depths[i - 2] < depths[i + 1])
                counter++;
        }
        
        return counter;
    }
}