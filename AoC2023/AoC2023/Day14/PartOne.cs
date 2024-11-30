using AoC.Shared;

namespace AoC2023.Day14;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var platform = File.ReadAllLines(Input)
                           .Select(x => x.Select(ParseTile)
                                         .ToArray())
                           .ToArray();

        TiltToNorth(platform);
        return CalculateLoadOfNorthBeam(platform);
    }

    private static Tile ParseTile(char symbol)
        => symbol switch
        {
            'O' => new RoundedRock(),
            '#' => new CubeShapedRock(),
            '.' => new EmptySpace(),
            _ => throw new Exception("Symbol does not exists")
        };

    private static void TiltToNorth(Tile[][] platform)
    {
        bool isAnyRockMoved;
        do
        {
            isAnyRockMoved = false;

            for (var y = 1; y < platform.Length; y++)
            {
                for (var x = 0; x < platform[y].Length; x++)
                {
                    if (CanRockMove(x, y, platform))
                    {
                        platform[y - 1][x] = platform[y][x];
                        platform[y][x] = new EmptySpace();
                        isAnyRockMoved = true;
                    }
                }
            }
        } while (isAnyRockMoved);
    }

    private static bool CanRockMove(int currX, int currY, Tile[][] platform)
        => currY >= 1
        && platform[currY][currX] is RoundedRock
        && platform[currY - 1][currX] is EmptySpace;

    private static int CalculateLoadOfNorthBeam(Tile[][] platform)
    {
        var rowLoadCounter = platform.Length;
        var totalLoad = 0;

        for (var y = 0; y < platform.Length; y++, rowLoadCounter--)
            totalLoad += platform[y].Count(x => x is RoundedRock) * rowLoadCounter;

        return totalLoad;
    }

    private record Tile(char Symbol);
    private record EmptySpace() : Tile('.');
    private record RoundedRock() : Tile('O');
    private record CubeShapedRock() : Tile('O');
}