namespace AoC2015.Day5;

public class PartTwo
{
    private const string inputFile = "Day5/input.txt";

    public long Solve()
    {
        return File.ReadAllLines(inputFile)
                   .Count(IsNiceString);
    }

    private bool IsNiceString(string value)
    {
        var pairLetters = new List<string>() { value[..2] };

        var flagOne = false;
        var flagTwo = false;

        for (var i = 2; i < value.Length; i++)
        {
            if (!flagOne)
            {
                var pair = value.Substring(i - 1, 2);
                if (pairLetters.Index().Any(x => x.Item == pair && x.Index != i - 2))
                {
                    flagOne = true;
                }
                else
                {
                    pairLetters.Add(pair);
                }
            }

            if (!flagTwo && value[i] == value[i - 2])
            {
                flagTwo = true;
            }

            if (flagOne && flagTwo)
            {
                return true;
            }
        }

        return false;
    }
}