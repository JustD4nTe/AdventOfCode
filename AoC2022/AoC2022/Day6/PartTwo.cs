namespace AoC2022.Day6;

internal static class PartTwo
{
    public static int Solution()
    {
        var input = File.ReadAllLines("Day6/input.txt")[0].ToArray();

        const int packetSize = 14;

        for (var i = packetSize; i < input.Length ; i++)
        {
            if (input[(i - packetSize)..i].ToHashSet().Count == packetSize)
                return i;
        }

        return -1;
    }
}
