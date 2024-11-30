using System.Text;

namespace AoC2022.Day13;

internal static class Temp
{
    public static long Solution()
    {
        var input = File.ReadAllLines("Day13/test.txt");

        var rightPairCounter = 0;

        for (int i = 0, j = 1; i < input.Length; i += 3, j++)
        {
            var firstPacket = input[i][1..^1];
            var secondPacket = input[i + 1][1..^1];
            var first = Format(ref firstPacket);
            var second = Format(ref secondPacket);
            
            Console.WriteLine(first.GetStringBuilder().ToString());
            Console.WriteLine(second.GetStringBuilder().ToString());
            Console.WriteLine();
            //if (first.Equals(second))
            //    rightPairCounter += j;
        }

        return rightPairCounter;
    }

    private class Packet : IEquatable<Packet>
    {
        public readonly List<Packet>? Packets;
        public readonly int? Value;

        public Packet()
        {
            Packets = new();
            Value = null;
        }

        public Packet(int? value)
        {
            Packets = null;
            Value = value;
        }

        public bool Equals(Packet? other)
        {
            if(other is null)
                return false;

            if (Value is not null && other.Value is not null)
                return Value < other.Value;

            for (var i = 0; i < Packets!.Count; i++)
            {

            }

            return Packets!.Count < other.Packets!.Count;
        }

        public StringBuilder GetStringBuilder()
        {
            var builder = new StringBuilder();

            if (Value is not null)
            {
                builder.Append(Value.ToString());
            }
            else
            {
                builder.Append('[');
                builder.Append(string.Join(",", Packets!.Select(x => x.GetStringBuilder())));
                builder.Append(']');
            }

            return builder;
        }

        public override bool Equals(object obj) 
            => Equals(obj as Packet);

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    private static Packet Format(ref string input)
    {
        var packet = new Packet();

        while (input.Length > 0)
        {
            if (input[0] == '[')
            {
                input = input[1..];
                packet.Packets!.Add(Format(ref input));
                continue;
            }
            
            if (input[0] == ']')
            {
                input = input[1..];
                return packet;
            }
            
            if (input[0] != ',')
            {
                var value = GetValue(input[0]);
                packet.Packets!.Add(new(value));
            }

            input = input[1..];
        };

        return packet;
    }

    private static int GetValue(char value)
        => int.Parse(value.ToString());
}