namespace AoC2015.Day2;

static class PartTwo
{
    private const string input = "Day2/input.txt";

    public static long Solve()
    {
        return File.ReadAllLines(input)
                   .Select(x => x.Split("x").Select(y => int.Parse(y)).ToArray())
                   .Select(CalculateRibbon)
                   .Sum();
    }

    private static long CalculateRibbon(int[] size)
    {
        Array.Sort(size);
        var wrapPresent = 2 * (size[0] + size[1]);
        var bow = size.Aggregate((x, y) => x * y);
        
        
        return wrapPresent + bow;
    }
}