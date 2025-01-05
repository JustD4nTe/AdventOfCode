using AoC.Shared;

namespace AoC2021.Day1;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var depths = File.ReadAllLines(Input).Select(int.Parse).ToArray();
        var counter = 0;
        for(var i = 1; i < depths.Length; i++)
        {
            if (depths[i - 1] < depths[i])
                counter++;
        }
        
        return counter;
    }
}