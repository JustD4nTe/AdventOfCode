using AoC.Shared;
using AoC.Shared.ValueObjects;
using System.Collections.Immutable;

namespace AoC2025.Day8;

public class PartOne(string input, int firstConnectionCount) : Solution(input)
{
    public override long Solve()
    {
        var junctionBoxes = File.ReadAllLines(Input)
            .Select(x => x.Split(",").Select(long.Parse).ToImmutableArray())
            .Select(x => new Position3D<long>(x[0], x[1], x[2]))
            .ToImmutableArray();

        var connections = new List<(int i1, int i2, double v)>();

        for (var i = 0; i < junctionBoxes.Length; i++)
        {
            for (var j = 0; j < junctionBoxes.Length; j++)
            {
                if (i == j)
                {
                    connections.Add((i, j, double.MaxValue));
                    continue;
                }

                connections.Add((i, j, GetDistance(junctionBoxes[i], junctionBoxes[j])));
            }
        }

        var topShortestConnections = connections.DistinctBy(x => x.v)
                                                .OrderBy(x => x.v)
                                                .Select(x => (x.i1, x.i2))
                                                .Take(firstConnectionCount);

        var circuits = new List<List<int>>();

        foreach (var (src, dst) in topShortestConnections)
        {
            var tmpSrc = circuits.SingleOrDefault(x => x.Any(y => y == src));
            var tmpDst = circuits.SingleOrDefault(x => x.Any(y => y == dst));

            if (tmpSrc != null && tmpSrc == tmpDst)
            {
                continue;
            }

            if (tmpSrc != null && tmpDst != null)
            {
                tmpSrc.AddRange([.. tmpDst]);
                circuits.Remove(tmpDst);
            }
            else if (tmpSrc != null && tmpDst == null)
            {
                tmpSrc.Add(dst);
            }
            else if (tmpSrc == null && tmpDst != null)
            {
                tmpDst.Add(src);
            }
            else
            {
                circuits.Add([src, dst]);
            }
        }

        return circuits.Select(x => x.Count)
                       .OrderByDescending(x => x)
                       .Take(3)
                       .Aggregate((x, y) => x * y);
    }

    private static double GetDistance(Position3D<long> p1, Position3D<long> p2)
        => (Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2) + Math.Pow((p1.Z - p2.Z), 2));
}