using System.Text;

namespace AoC2022.Day13;

internal static class PartOne
{
    public static long Solution()
    {
        var input = File.ReadAllLines("Day13/input.txt");

        var rightPairCounter = 0;

        for (int i = 0, j = 1; i < input.Length; i += 3, j++)
        {
            var firstPacket = input[i][1..^1];
            var secondPacket = input[i + 1][1..^1];
            var first = Format(ref firstPacket);
            var second = Format(ref secondPacket);

            Console.WriteLine($"\n== Pair {j} ==");
            Console.WriteLine(first.GetStringBuilder().ToString());
            Console.WriteLine(second.GetStringBuilder().ToString());
            Console.WriteLine();

            try
            {
                first.IsEqual(second);
            }
            catch (RightException)
            {
                rightPairCounter += j;
            }
            catch (WrongException)
            {
            }
            catch
            {
            }

        }

        return rightPairCounter;
    }

    private class RightException : Exception { }
    private class WrongException : Exception { }

    private class Packet
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

        public void IsEqual(Packet other)
        {
            Console.WriteLine("Compare: " + GetStringBuilder().ToString() + " vs " + other.GetStringBuilder().ToString());

            if (Packets is null && other.Packets is null)
            {
                if (Value < other.Value)
                {
                    Console.WriteLine("Left side is smaller, so inputs are in the right order");
                    throw new RightException();
                }
                if (Value > other.Value)
                {
                    Console.WriteLine("Right side is smaller, so inputs are not in the right order");
                    throw new WrongException();
                }
                if (Value == other.Value)
                    return;
            }

            if (Packets is not null && other.Packets is not null)
            {
                for (var i = 0; i < Packets!.Count; i++)
                {
                    if (i == other.Packets!.Count)
                    {
                        Console.WriteLine("Right side ran out of items, so inputs are not in the right order");
                        throw new WrongException();
                    }

                    Packets[i].IsEqual(other.Packets![i]);
                }

                if (Packets!.Count < other.Packets!.Count)
                {
                    Console.WriteLine("Left side ran out of items, so inputs are in the right order");
                    throw new RightException();
                }
                return;
            }

            if (Value is null && other.Packets is null)
            {
                if (Packets!.Count == 0)
                {
                    Console.WriteLine("Left side ran out of items, so inputs are in the right order");
                    throw new RightException();
                }
                Packets![0].IsEqual(other);
            }
            else
            {
                if (other.Packets!.Count == 0)
                {
                    Console.WriteLine("Right side ran out of items, so inputs are not in the right order");
                    throw new WrongException();
                }

                IsEqual(other.Packets![0]);
            }
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
            else if (input[0] == ']')
            {
                input = input[1..];
                return packet;
            }
            else if (input[0] != ',')
            {
                if (input.Length > 1 && int.TryParse(input[..2], out int tempOne))
                {
                    packet.Packets!.Add(new(tempOne));
                    input = input[2..];
                }
                else if (int.TryParse(input[..1].ToString(), out int tempTwo))
                {
                    packet.Packets!.Add(new(tempTwo));
                    input = input[1..];
                }
            }
            else
            {
                input = input[1..];
            }

        };

        return packet;
    }
}