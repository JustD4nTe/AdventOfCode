using System.Security.Cryptography;
using System.Text;

namespace AoC2015.Day4;

public class PartOne
{
    public long Solve()
    {
        var input = "iwrupvqb";
        var i = 0;
        for (; ; i++)
        {
            if (Md5($"{input}{i}")[..5].All(x => x == '0'))
            {
                return i;
            }
        }
    }

    private string Md5(string input) => Convert.ToHexString(MD5.HashData(Encoding.ASCII.GetBytes(input)));
}