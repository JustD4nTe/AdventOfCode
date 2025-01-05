using AoC.Shared;

namespace AoC2021.Day7;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var crabs = File.ReadAllText(Input).Split(",").Select(int.Parse).ToArray();

        var min = int.MaxValue;

        for(var i = 1; i <= crabs.Max(); i++)
        {
            var acc = 0;
            
            foreach (var crab in crabs)
            {
                acc += Math.Abs(crab - i);
                
                if(acc >= min)
                    break;
            }

            if (acc < min)
                min = acc;
        }

        return min;
    }
}