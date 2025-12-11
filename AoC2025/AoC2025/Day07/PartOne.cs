using AoC.Shared;

namespace AoC2025.Day07;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var tachylonManifoldsDiagram = File.ReadAllLines(Input)
            .Select(x => x.ToCharArray())
            .ToArray();

        var beamYTracker = new List<int> { tachylonManifoldsDiagram[0].IndexOf('S') };
        var splitTracker = 0L;

        for (var y = 0; y < tachylonManifoldsDiagram.Length - 1; y++)
        {
            var newBeamsY = new List<int>();
            foreach (var beam in beamYTracker)
            {
                if (tachylonManifoldsDiagram[y + 1][beam] == '^')
                {
                    newBeamsY.Add(beam - 1);
                    newBeamsY.Add(beam + 1);
                    splitTracker++;
                }
                else
                {
                    newBeamsY.Add(beam);
                }
            }

            beamYTracker = [.. newBeamsY.Distinct()];
        }

        return splitTracker;
    }
}