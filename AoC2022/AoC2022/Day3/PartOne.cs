namespace AoC2022.Day3;

internal static class PartOne
{
    public static async Task<int> Solution()
    {
        var duplicates = new List<char>();

        await foreach (var line in File.ReadLinesAsync("Day3/input.txt"))
        {
            var halfIndex = line.Length / 2;
            var firstHalf = line[..halfIndex];
            var secondHalf = line[halfIndex..];
            duplicates.AddRange(firstHalf.Intersect(secondHalf));
        }

        return duplicates.Select(x => ParseItem(x)).Sum(); ;
    }

    private static int ParseItem(int item)
        => item > 96 ? item - 96 : item - 38;
}
