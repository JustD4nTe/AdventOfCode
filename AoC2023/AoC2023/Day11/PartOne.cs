using AoC.Shared;

namespace AoC2023.Day11;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
                           .Select(x => x.ToCharArray().ToList())
                           .ToList();

        var img = ExpandImage(rawInput);
        var galaxies = GetGalaxies(img);

        var result = 0;

        for (var i = 0; i < galaxies.Count - 1; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                result += CalculateDistance(galaxies[i], galaxies[j]);
            }
        }

        return result;
    }

    private static char[][] ExpandImage(List<List<char>> img)
    {
        for (var i = 0; i < img.Count; i++)
        {
            if (img[i].Any(x => x != '.')) 
                continue;
            
            img.Insert(i, img[i]);
            i++;
        }

        for (var i = 0; i < img[0].Count; i++)
        {
            if (img.Any(x => x[i] != '.')) 
                continue;
            
            foreach (var t in img)
                t.Insert(i, '.');

            i++;
        }

        return img.Select(x => x.ToArray()).ToArray();
    }

    private static List<Position> GetGalaxies(char[][] img)
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

        return galaxyPositions;
    }

    // private static decimal CalculateDistance(Position p1, Position p2)
    //     => Math.Round((decimal)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)), MidpointRounding.ToPositiveInfinity);

    private static int CalculateDistance(Position p1, Position p2)
    {
        var stepCounter = 0;

        var x = p2.X;
        var y = p2.Y;

        do
        {
            if (p1.X > x)
            {
                x++;
                stepCounter++;
            }
            else if (p1.X < x)
            {
                x--;
                stepCounter++;
            }

            if (p1.Y > y)
            {
                y++;
                stepCounter++;
            }
            else if (p1.Y < y)
            {
                y--;
                stepCounter++;
            }

        } while (p1.X != x || p1.Y != y);

        return stepCounter;
    }

    private record Position(int X, int Y);
}