using AoC.Shared;

namespace AoC2025.Day04;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var map = File.ReadAllLines(Input)
            .Select(x => x.ToCharArray())
            .ToArray();

        var possibleAccessRollPaperCount = 0;

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '.')
                    continue;

                var adjacentRollsCount = 0;

                // up left
                if (y > 0 && x > 0 && map[y - 1][x - 1] == '@')
                    adjacentRollsCount++;

                // up 
                if (y > 0 && map[y - 1][x] == '@')
                    adjacentRollsCount++;

                // up right
                if (y > 0 && x < map[y].Length - 1 && map[y - 1][x + 1] == '@')
                    adjacentRollsCount++;

                // left
                if (x > 0 && map[y][x - 1] == '@')
                    adjacentRollsCount++;

                // right
                if (x < map[y].Length - 1 && map[y][x + 1] == '@')
                    adjacentRollsCount++;

                // down left
                if (y < map.Length - 1 && x > 0 && map[y + 1][x - 1] == '@')
                    adjacentRollsCount++;

                // down
                if (y < map.Length - 1 && map[y + 1][x] == '@')
                    adjacentRollsCount++;

                // down right
                if (y < map.Length - 1 && x < map[y].Length - 1 && map[y + 1][x + 1] == '@')
                    adjacentRollsCount++;

                if (adjacentRollsCount < 4)
                    possibleAccessRollPaperCount++;
            }
        }

        return possibleAccessRollPaperCount;
    }
}