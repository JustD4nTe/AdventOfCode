namespace AoC2022.Day1
{
    internal static class PartOne
    {
        public static long Solution()
        {
            using var sr = new StreamReader("../../../Day1/input.txt");

            var foodKcals = sr.ReadToEnd()
                              .Split("\n");

            var kcalSum = new List<long>();
            long kcalCounter = 0;
            foreach (var foodKcal in foodKcals)
            {
                if (string.IsNullOrWhiteSpace(foodKcal))
                {
                    kcalSum.Add(kcalCounter);
                    kcalCounter = 0;
                }
                else
                {
                    kcalCounter += long.Parse(foodKcal);
                }
            }

            return kcalSum.Max();
        }
    }
}
