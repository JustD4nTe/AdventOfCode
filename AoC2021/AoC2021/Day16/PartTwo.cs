using AoC.Shared;
using System.Text;

namespace AoC2021.Day16;

public class PartTwo(string input) : Solution(input)
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

    private record PackageInfo(int Length, long Result);

    private static PackageInfo HandlePackage(ReadOnlySpan<char> package)
    {
        //var packetVersion = Convert.ToUInt64(package[..3].ToString(), 2);
        var typeID = Convert.ToInt32(package[3..6].ToString(), 2);

        var (i, v) = typeID switch
        {
            0 => HandleSumPackage(package[6..]),
            1 => HandleProductPackage(package[6..]),
            2 => HandleMinPackage(package[6..]),
            3 => HandleMaxPackage(package[6..]),
            4 => HandleLiteralPackage(package[6..]),
            5 => HandleGreaterThanPackage(package[6..]),
            6 => HandleLessThanPackage(package[6..]),
            7 => HandleEqualToPackage(package[6..]),
            _ => throw new NotImplementedException()
        };

        return new(i + 6, v);
    }

    private static PackageInfo HandleSumPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = 0L;
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
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

    private static PackageInfo HandleProductPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = 1L;
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
                j += subI;
                result *= subRes;
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
                result *= subRes;
            }

        }

        return new(i, result);
    }

    private static PackageInfo HandleMinPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = new List<long>();
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
                j += subI;
                result.Add(subRes);
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
                result.Add(subRes);
            }
        }

        return new(i, result.Min());
    }

    private static PackageInfo HandleMaxPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = new List<long>();
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
                j += subI;
                result.Add(subRes);
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
                result.Add(subRes);
            }

        }

        return new(i, result.Max());
    }

    private static PackageInfo HandleGreaterThanPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = new List<long>();
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
                j += subI;
                result.Add(subRes);
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
                result.Add(subRes);
            }

        }

        return new(i, result[0] > result[1] ? 1L : 0L);
    }

    private static PackageInfo HandleLessThanPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = new List<long>();
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
                j += subI;
                result.Add(subRes);
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
                result.Add(subRes);
            }
        }

        return new(i, result[0] < result[1] ? 1L : 0L);
    }

    private static PackageInfo HandleEqualToPackage(ReadOnlySpan<char> package)
    {
        var i = 0;
        var result = new List<long>();
        var lengthTypeID = package[0];

        if (lengthTypeID == '0')
        {
            i = 16;
            var totalSubPackageLength = Convert.ToInt32(package[1..i].ToString(), 2);
            var j = 0;
            do
            {
                var (subI, subRes) = HandlePackage(package[(i + j)..]);
                j += subI;
                result.Add(subRes);
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
                result.Add(subRes);
            }

        }

        return new(i, result[0] == result[1] ? 1L : 0L);
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

        return new(i, Convert.ToInt64(strBuilder.ToString(), 2));
    }
}