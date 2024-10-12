namespace AoC2015.Day1;

public class PartOne
{
    private const string input = "Day1/input.txt";
    public long Solve()
    {
        var temp = File.ReadAllLines(input)[0];
        var up = temp.Count(x => x == '(');
        var down = temp.Count(x => x == ')');

        return up - down;
    }
}