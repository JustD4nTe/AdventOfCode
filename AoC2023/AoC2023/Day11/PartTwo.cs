using AoC.Shared;

namespace AoC2023.Day11;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var img = File.ReadAllLines(Input)
                           .Select(x => x.ToCharArray())
                           .ToArray();

        var galaxies = GetGalaxies(img);
        ExpandGalaxies(galaxies, img);

        long result = 0;

        for (var i = 0; i < galaxies.Length - 1; i++)
        {
            result += galaxies[(i + 1)..].Sum(x => galaxies[i] - x);
        }

        return result;
    }

    private static void ExpandGalaxies(Position[] galaxies, char[][] img)
    {
        const int expandSize = 1_000_000 - 1;
        for (int y = 0, expandedY = 0; y < img.Length; y++, expandedY++)
        {
            if (img[y].Any(x => x != '.')) 
                continue;
            
            for (var i = 0; i < galaxies.Length; i++)
            {
                if (galaxies[i].Y > expandedY)
                    galaxies[i] = new Position(galaxies[i].X, galaxies[i].Y + expandSize);
            }
            expandedY += expandSize;
        }

        for (int x = 0, expandedX = 0; x < img[0].Length; x++, expandedX++)
        {
            if (img.Any(p => p[x] != '.')) 
                continue;
            
            for (var i = 0; i < galaxies.Length; i++)
            {
                if (galaxies[i].X > expandedX)
                    galaxies[i] = new Position(galaxies[i].X + expandSize, galaxies[i].Y);
            }
            expandedX += expandSize;
        }

    }

    private static Position[] GetGalaxies(char[][] img)
    {
        var galaxyPositions = new List<Position>();

        for (var y = 0; y < img.Length; y++)
        {
            for (var x = 0; x < img[y].Length; x++)
            {
                if (img[y][x] == '#')
                    galaxyPositions.Add(new(x, y));
            }
        }

        return galaxyPositions.ToArray();
    }

    private record Position(long X, long Y)
    {
        public static long operator -(Position p1, Position p2)
            => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
    }
}