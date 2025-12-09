using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day17;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var trenchPosition = File.ReadAllText(Input)
            .Split(": ")[1]
            .Split(", ")
            .Select(x => x[2..].Split("..")
                               .Select(int.Parse)
                               .ToArray())
            .ToArray();

        var trenchMinX = trenchPosition[0][0];
        var trenchMaxX = trenchPosition[0][1];
        var trenchMinY = trenchPosition[1][0];
        var trenchMaxY = trenchPosition[1][1];
       
        var highestThrow = 0;

        for (var xStartVelocity = 0; xStartVelocity <= 100; xStartVelocity++)
        {
            for (var yStartVelocity = -100; yStartVelocity <= 100; yStartVelocity++)
            {
                var xVelocity = xStartVelocity;
                var yVelocity = yStartVelocity;

                var probe = new Position2D(0, 0);

                var localHighestThrow = 0;
                var isScored = false;

                do
                {
                    if(localHighestThrow < probe.Y)
                        localHighestThrow = probe.Y;

                    if (probe.X >= trenchMinX && probe.X <= trenchMaxX 
                     && probe.Y >= trenchMinY && probe.Y <= trenchMaxY)
                    {
                        isScored = true;
                        break;
                    }

                    probe = new Position2D(probe.X + xVelocity, probe.Y + yVelocity);

                    // dut to drag change x velocity closer to 0
                    if (xVelocity > 0)
                        xVelocity--;
                    else if(xVelocity < 0)
                        xVelocity++;
                    
                    // due to gravity
                    yVelocity--;

                } while (probe.Y >= trenchMinY);

                if (isScored && highestThrow < localHighestThrow)
                    highestThrow = localHighestThrow;
            }
        }

        return highestThrow;
    }
}