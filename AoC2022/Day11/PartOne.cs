namespace AoC2022.Day11;

internal static class PartOne
{
    class Test
    {
        public int DividedBy { get; set; }
        public int TrueMonkeyId { get; set; }
        public int FalseMonkeyId { get; set; }

        public Test(int dividedBy, int trueMonkeyId, int falseMonkeyId)
        {
            DividedBy = dividedBy;
            TrueMonkeyId = trueMonkeyId;
            FalseMonkeyId = falseMonkeyId;
        }

        public int GetTargetMonkey(int currItem) 
            => currItem % DividedBy == 0 ? TrueMonkeyId : FalseMonkeyId;
    }

    class Monkey
    {
        private Func<int, int> _operation;
        public Queue<int> StartingItems { get; }

        public Func<int, int> Operation {
            get
            {
                InspectedItemsCounter++;
                return _operation;
            }
            set => _operation = value;
        }
        public Test Test { get;}

        public int InspectedItemsCounter { get; set; }

        public Monkey(Queue<int> startingItems, Func<int, int> operation, Test test)
        {
            StartingItems = startingItems;
            _operation = operation;
            Test = test;

            InspectedItemsCounter = 0;
        }
    }

    public static long Solution()
    {
        var input = File.ReadAllLines("Day11/input.txt");
        var monkeys = new List<Monkey>();
        Initialize(input, monkeys);

        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys.Where(x => x.StartingItems.Any()))
            {
                while (monkey.StartingItems.TryDequeue(out int currItem))
                {
                    currItem = monkey.Operation(currItem);
                    currItem /= 3;
                    var throwToMonkeyId = monkey.Test.GetTargetMonkey(currItem);
                    monkeys[throwToMonkeyId].StartingItems.Enqueue(currItem);
                };
            }

            Console.WriteLine($"After round {i + 1}, the monkeys are holding items with these worry levels:");

            for (var j = 0; j < monkeys.Count; j++)
                Console.WriteLine($"Monkey {j}: {string.Join(", ", monkeys[j].StartingItems)}");
        }

        return monkeys.Select(x => x.InspectedItemsCounter)
                      .OrderByDescending(x => x)
                      .Take(2)
                      .Aggregate((a, x) => a * x);
    }

    private static void Initialize(string[] input, List<Monkey> monkeys)
    {
        for (var i = 1; i < input.Length; i += 7)
        {
            var startingItems = input[i].Split(":")[1]
                                        .Split(",", StringSplitOptions.TrimEntries)
                                        .Select(int.Parse);

            var temp = input[i + 1].Split("=", StringSplitOptions.TrimEntries)[1]
                                   .Split(" ", StringSplitOptions.TrimEntries);
            var operation = CreateOperation(temp);

            var devidedBy = int.Parse(input[i + 2].Split(" ")[^1]);
            var trueMonkeyId = int.Parse(input[i + 3].Split(" ")[^1]);
            var falseMonkeyId = int.Parse(input[i + 4].Split(" ")[^1]);

            var test = new Test(devidedBy, trueMonkeyId, falseMonkeyId);

            monkeys.Add(new(new Queue<int>(startingItems), operation, test));
        }
    }

    private static Func<int, int> CreateOperation(string[] temp)
    {
        Func<int, int> operation = _ => -1;

        if (temp[1] == "*")
        {
            if (temp[2] == "old")
            {
                operation = old => old * old;
            }
            else
            {
                var num = int.Parse(temp[2]);
                operation = old => old * num;
            }
        }
        else if (temp[1] == "+")
        {
            if (temp[2] == "old")
            {
                operation = old => old + old;
            }
            else
            {
                var num = int.Parse(temp[2]);
                operation = old => old + num;
            }
        }
        return operation;
    }
}