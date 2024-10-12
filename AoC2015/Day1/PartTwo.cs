namespace AoC2015.Day1;

public class PartTwo
{
    private const string input = "Day1/input.txt";

    public long Solve()
    {
        var temp = File.ReadAllLines(input)[0];

        var position = 1;
        var floor = 0;

        foreach (var foo in temp)
        {
            if (foo == '(')
                floor++;
            else
                floor--;

            if (floor == -1)
                return position;

            position++;
        }

        return -1;
    }
}