using System.Collections.Specialized;
using System.Text;
using AoC.Shared;

namespace AoC2024.Day24;

public class PartOne(string input) : Solution(input)
{
    private readonly Dictionary<string, bool> _register = new();

    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n").Select(x => x.Split("\r\n")).ToArray();

        foreach (var line in rawInput[0])
        {
            var buff = line.Split(": ");
            _register[buff[0]] = buff[1] == "1";
        }

        var operations = new List<Operation>();

        foreach (var line in rawInput[1])
        {
            var buff = line.Split(" -> ");
            var output = buff[1];

            buff = buff[0].Split(" ");
            var wireA = buff[0];
            var wireB = buff[2];
            var operationType = Enum.Parse<OperationType>(buff[1].ToUpper());
            operations.Add(new Operation(wireA, wireB, operationType, output));
        }

        var i = 0;
        while (operations.Count > 0)
        {
            i %= operations.Count;

            var currOperation = operations[i];
            if (_register.TryGetValue(currOperation.WireA, out var wireA) &&
                _register.TryGetValue(currOperation.WireB, out var wireB))
            {
                _register[currOperation.Output] = currOperation.OperationType switch
                {
                    OperationType.AND => And(wireA, wireB),
                    OperationType.OR => Or(wireA, wireB),
                    OperationType.XOR => Xor(wireA, wireB),
                    _ => throw new ArgumentOutOfRangeException()
                };

                operations.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        var values = _register.Where(x => x.Key.StartsWith('z'))
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToArray();

        long result = 0;

        var xNumber = GetNumber(_register.Where(x => x.Key.StartsWith('x'))
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToArray());
        var yNumber = GetNumber(_register.Where(x => x.Key.StartsWith('y'))
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToArray());
        var resultNumber = GetNumber(_register.Where(x => x.Key.StartsWith('z'))
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToArray());

        for (i = 0; i < values.Length; i++)
            result += values[i] ? (long)Math.Pow(2, i) : 0;

        return result;
    }

    private static string GetNumber(bool[] values)
    {
        int i;
        var strBuilder = new StringBuilder();
        for (i = values.Length - 1; i >= 0; i--)
            strBuilder.Append(values[i] ? '1' : '0');

        return strBuilder.ToString();
    }

    private enum OperationType
    {
        AND,
        OR,
        XOR
    }

    private record Operation(string WireA, string WireB, OperationType OperationType, string Output);

    private static bool And(bool a, bool b) => a && b;
    private static bool Or(bool a, bool b) => a || b;
    private static bool Xor(bool a, bool b) => a ^ b;
}