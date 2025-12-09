using AoC.Shared;
using System.Text;

namespace AoC2021.Day16;

public class PartOne(string input) : Solution(input)
{
    private readonly Dictionary<char, string> _hexDecode = new()
    {
        ['0'] = "0000",
        ['1'] = "0001",
        ['2'] = "0010",
        ['3'] = "0011",
        ['4'] = "0100",
        ['5'] = "0101",
        ['6'] = "0110",
        ['7'] = "0111",
        ['8'] = "1000",
        ['9'] = "1001",
        ['A'] = "1010",
        ['B'] = "1011",
        ['C'] = "1100",
        ['D'] = "1101",
        ['E'] = "1110",
        ['F'] = "1111"
    };

    public override long Solve()
    {
        var package = string.Join("", File.ReadAllText(Input)
            .ToCharArray()
            .Select(x => _hexDecode[x]))
            .AsSpan();

        var (i, result) = HandlePackage(package);

        return result;
    }

    private record PackageInfo(int Length, int Result);

    private static PackageInfo HandlePackage(ReadOnlySpan<char> package)
    {
        var packetVersion = Convert.ToInt32(package[..3].ToString(), 2);
        var typeID = Convert.ToInt32(package[3..6].ToString(), 2);

        if (typeID == 4)
        {
            var (i, tmp) = HandleLiteralPackage(package[6..]);
            return new(i + 6, packetVersion + tmp);
        }
        else
        {
            var (i, tmp) = HandleOperationPackage(package[6..]);
            return new(i + 6, packetVersion + tmp);
        }
    }

    private static PackageInfo HandleLiteralPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var strBuilder = new StringBuilder();
        bool isNotLast;
        do
        {
            var group = package[i..(i + 5)];
            isNotLast = group[0] == '1';
            strBuilder.Append(group[1..]);

            i += 5;
        } while (isNotLast);

        return new(i, 0);
    }

    private static PackageInfo HandleOperationPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = 0;
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i  + j)..]);
                j += subI;
                result += subRes;
            } while (j < totalSubPackageLength);

            i += j;
        }
        else if (lengthTypeID == '1')
        {
            i = 12;
            var numberOfSubPackages = Convert.ToInt32(package[1..i].ToString(), 2);
            
            for (var j = 0; j < numberOfSubPackages; j++)
            {
                var (subI, subRes) = HandlePackage(package[i..]);
                i += subI;
                result += subRes;
            }

        }
        
        return new(i, result);
    }
}