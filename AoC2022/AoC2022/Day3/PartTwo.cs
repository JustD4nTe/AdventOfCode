namespace AoC2022.Day3;

internal static class PartTwo
{
    public static async Task<int> Solution()
    {
        var badges = new List<char>();
        var elfGroup = new List<string>();

        await foreach (var line in File.ReadLinesAsync("Day3/input.txt"))
        {
            elfGroup.Add(line);

            if (elfGroup.Count == 3)
            {
                var firstIntersect = elfGroup[0].Intersect(elfGroup[1]);

                badges.AddRange(firstIntersect.Intersect(elfGroup[2]));

                elfGroup.Clear();
            }
        }

        return badges.Select(x => ParseItem(x)).Sum();
    }

    private static int ParseItem(int item)
        => item > 96 ? item - 96 : item - 38;
}
