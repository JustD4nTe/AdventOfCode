using AoC.Shared;
using System.Text;

namespace AoC2025.Day2;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input)
            .Split(",");

        var invalidIdsSum = 0L;

        foreach (var line in rawInput)
        {
            var temp = line.Split("-");
            var first = long.Parse(temp[0]);
            var second = long.Parse(temp[1]);

            for (var i = first; i <= second; i++)
            {
                if (IsPalindrome(i.ToString()))
                {
                    invalidIdsSum += i;
                }
            }
        }


        return invalidIdsSum;
    }

    private static bool IsPalindrome(string v)
    {
        var strBuilder = new StringBuilder();

        for (var i = 1; i <= v.Length / 2; i++)
        {
            strBuilder.Append(v[i - 1]);

            if (v.Length % i != 0)
                continue;


            var buff = new List<string>();
            var tmp = 1;

            do
            {
                var l = i * (tmp - 1);
                var r = i * tmp;
                buff.Add(v[l..r]);

                tmp++;
            } while (tmp <= (v.Length / i));

            if (buff.All(x => x == strBuilder.ToString()))
                return true;
        }

        return false;
    }
}