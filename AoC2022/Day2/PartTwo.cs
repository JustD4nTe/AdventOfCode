namespace AoC2022.Day2
{
    internal static class PartOne
    {
        public static long Solution()
        {
            var win = new List<string>()
            {
                "A Y",
                "B Z",
                "C X"
            };
            
            var draw = new List<string>()
            {
                "A X",
                "B Y",
                "C Z"
            };

            var shapes = new List<string>()
            {
                "X","Y","Z"
            };

            using var sr = new StreamReader("../../../Day2/input.txt");

            var rounds = sr.ReadToEnd()
                              .Split("\n");

            var points = 0;

            foreach (var round in rounds)
            {
                if (win.Contains(round))
                    points += 6;
                else if(draw.Contains(round))
                    points += 3;


                points += shapes.IndexOf(round.Split(' ')[1]) + 1;
            }

            return points;
        }
    }
}
