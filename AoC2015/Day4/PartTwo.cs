using System.Security.Cryptography;
using System.Text;

namespace AoC2015.Day4;

public class PartTwo
{
    public long Solve()
    {
        var input = "iwrupvqb";
        var i = 346386;
        for (; ; i++)
        {
            if (Md5($"{input}{i}")[..6].All(x => x == '0'))
            {
                return i;
            }
        }
    }

    private string Md5(string input) => Convert.ToHexString(MD5.HashData(Encoding.ASCII.GetBytes(input)));
}