namespace AoC2022.Day2
{
    internal static class PartTwo
    {
        enum WhatToDo
        {
            Win,
            Draw,
            Lose
        }

        public static long Solution()
        {
            var whatToDo = new Dictionary<string, WhatToDo>()
            {
                ["X"] = WhatToDo.Lose,
                ["Y"] = WhatToDo.Draw,
                ["Z"] = WhatToDo.Win
            };

            var win = new Dictionary<string, int>()
            {
                ["A"] = 8,
                ["B"] = 9,
                ["C"] = 7,
            };

            var draw = new Dictionary<string, int>()
            {
                ["A"] = 4,
                ["B"] = 5,
                ["C"] = 6,
            };
            
            var lose = new Dictionary<string, int>()
            {
                ["A"] = 3,
                ["B"] = 1,
                ["C"] = 2,
            };

            using var sr = new StreamReader("../../../Day2/input.txt");

            var rounds = sr.ReadToEnd()
                              .Split("\n");

            var points = 0;

            foreach (var round in rounds)
            {
                var roundPoints = 0;
                var shapes = round.Split(" ");
                switch (whatToDo[shapes[1]])
                {
                    case WhatToDo.Win:
                        roundPoints += win[shapes[0]];
                        break;
                    case WhatToDo.Draw:
                        roundPoints += draw[shapes[0]];
                        break;
                    case WhatToDo.Lose:
                        roundPoints += lose[shapes[0]];
                        break;
                }
                 points += roundPoints;
            }

            return points;
        }
    }
}
