namespace AoC2015.Day5;

static class PartOne
{
    private const string inputFile = "Day5/input.txt";
    
    private static readonly string[] forbiddenStrings = ["ab", "cd", "pq", "xy"];
    private static readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];
    
    public static long Solve()
    {
        return File.ReadAllLines(inputFile)
                   .Count(IsNiceString);
    }

    private static bool IsNiceString(string value)
    {
        // It does not contain the strings ab, cd, pq, or xy
        if (forbiddenStrings.Any(value.Contains))
            return false;

        // It contains at least three vowels
        if (value.Count(x => vowels.Contains(x)) < 3)
            return false;

        // It contains at least one letter that appears twice in a row
        for (var i = 0; i < value.Length - 1; i++)
        {
            if (value[i] == value[i + 1])
                return true;
        }


        return false;
    }
}