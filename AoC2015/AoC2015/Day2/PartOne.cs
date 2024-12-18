namespace AoC2015.Day2;

public class PartOne
{
    private const string input = "Day2/input.txt";

    public long Solve()
    {
        return File.ReadAllLines(input)
                   .Select(x => x.Split("x").Select(y => int.Parse(y)).ToArray())
                   .Select(CalculateArea)
                   .Sum();
    }

    private long CalculateArea(int[] size)
    {
        var boxArea = 2 * size[0] * size[1] + 2 * size[1] * size[2] + 2 * size[2] * size[0];
        Array.Sort(size);
        
        return boxArea + size[0] * size[1];
    }
}