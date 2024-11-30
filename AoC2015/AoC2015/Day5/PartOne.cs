namespace AoC2015.Day5;

public class PartOne
{
    private const string inputFile = "Day5/input.txt";
    
    private readonly string[] forbiddenStrings = ["ab", "cd", "pq", "xy"];
    private readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];
    
    public long Solve()
    {
        return File.ReadAllLines(inputFile)
                   .Count(IsNiceString);
    }

    private bool IsNiceString(string value)
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