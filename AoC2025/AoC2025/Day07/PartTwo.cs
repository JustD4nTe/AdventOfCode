using AoC.Shared;
using AoC.Shared.Helpers;

namespace AoC2025.Day07;

public class PartTwo(string input) : Solution(input)
{
    private char[][] _tachylonManifoldsDiagram = [];

    public override long Solve()
    {
        _tachylonManifoldsDiagram = [.. File.ReadAllLines(Input).Select(x => x.ToCharArray())];

        Func<int, int, long> sentParticle = null!;
        sentParticle = FuncHelpers.Memoize((int beam, int y) =>
        {
            if (y == _tachylonManifoldsDiagram.Length - 1)
                return 1;

            return _tachylonManifoldsDiagram[y + 1][beam] == '^' // chekc if split beam occured
                ? sentParticle(beam - 1, y + 1) + sentParticle(beam + 1, y + 1)
                : sentParticle(beam, y + 1);
        });

        return sentParticle(_tachylonManifoldsDiagram[0].IndexOf('S'), 1);
    }
}