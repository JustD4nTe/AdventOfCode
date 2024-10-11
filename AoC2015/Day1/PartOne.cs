using System.Text.RegularExpressions;

namespace AoC2015.Day1;

static class PartOne
{
    static string input = "Day1/input.txt";
    public static long Solve()
    {
        var temp = File.ReadAllLines(input)[0];
        var up = temp.Count(x => x == '(');
        var down = temp.Count(x => x == ')');

        return up - down;
    }
}