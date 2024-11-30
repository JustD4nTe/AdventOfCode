namespace AoC2022.Day4;

internal static class PartTwo
{
    private record Range
    {
        public int LowRange { get; }
        public int HighRange { get; }

        public Range(string range)
        {
            var buff = range.Split("-");
            LowRange = int.Parse(buff[0]);
            HighRange = int.Parse(buff[1]);
        }

        public bool Contains(Range range)
            => IsContainsEntire(range) || IsContainsEdge(range) || IsContainsPartly(range);

        private bool IsContainsEntire(Range range)
            => range.LowRange >= LowRange && range.HighRange <= HighRange;

        private bool IsContainsEdge(Range range)
            => range.LowRange == LowRange || range.HighRange == HighRange;

        private bool IsContainsPartly(Range range)
            => range.LowRange <= LowRange && range.HighRange >= LowRange;
    }

    public static async Task<int> Solution()
    {
        var pairOfElfs = new List<List<Range>>();

        await foreach (var line in File.ReadLinesAsync("Day4/input.txt"))
        {
            var elfs = line.Split(",");

            pairOfElfs.Add(new List<Range>()
            {
                new(elfs[0]),
                new(elfs[1])
            });
        }

        var fullyContainsCounter = 0;

        foreach (var pair in pairOfElfs)
        {
            if (pair[0].Contains(pair[1]) || pair[1].Contains(pair[0]))
                fullyContainsCounter++;
        }

        return fullyContainsCounter;
    }
}
