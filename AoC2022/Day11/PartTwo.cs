using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoC2022.Day11;

internal static class PartTwo
{
    class Test
    {
        public long DividedBy { get; set; }
        public int TrueMonkeyId { get; set; }
        public int FalseMonkeyId { get; set; }

        public Test(long dividedBy, int trueMonkeyId, int falseMonkeyId)
        {
            DividedBy = dividedBy;
            TrueMonkeyId = trueMonkeyId;
            FalseMonkeyId = falseMonkeyId;
        }

        public int GetTargetMonkey(long currItem) 
            => currItem % DividedBy == 0 ? TrueMonkeyId : FalseMonkeyId;
    }

    class Monkey
    {
        private Func<long, long> _operation;
        public Queue<long> StartingItems { get; }

        public Func<long, long> Operation {
            get
            {
                InspectedItemsCounter++;
                return _operation;
            }
            set => _operation = value;
        }
        public Test Test { get;}

        public long InspectedItemsCounter { get; set; }

        public Monkey(Queue<long> startingItems, Func<long, long> operation, Test test)
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

        //var modulo = 96577; // for test
        var modulo = 9699690; // for input

        Initialize(input, monkeys, modulo);
        for (var i = 0; i < 10_000; i++)
        {
            foreach (var monkey in monkeys.Where(x => x.StartingItems.Any()))
            {
                while (monkey.StartingItems.TryDequeue(out long currItem))
                {
                    currItem = monkey.Operation(currItem);
                    var throwToMonkeyId = monkey.Test.GetTargetMonkey(currItem);
                    monkeys[throwToMonkeyId].StartingItems.Enqueue(currItem);
                };
            }
        }

        return monkeys.Select(x => x.InspectedItemsCounter)
                      .OrderByDescending(x => x)
                      .Take(2)
                      .Aggregate((a, x) => a * x);
    }

    private static void Initialize(string[] input, List<Monkey> monkeys, int number)
    {
        for (var i = 1; i < input.Length; i += 7)
        {
            var startingItems = input[i].Split(":")[1]
                                        .Split(",", StringSplitOptions.TrimEntries)
                                        .Select(x => long.Parse(x) % number);

            var temp = input[i + 1].Split("=", StringSplitOptions.TrimEntries)[1]
                                   .Split(" ", StringSplitOptions.TrimEntries);
            var operation = CreateOperation(temp, number);

            var devidedBy = long.Parse(input[i + 2].Split(" ")[^1]);
            var trueMonkeyId = int.Parse(input[i + 3].Split(" ")[^1]);
            var falseMonkeyId = int.Parse(input[i + 4].Split(" ")[^1]);

            var test = new Test(devidedBy, trueMonkeyId, falseMonkeyId);

            monkeys.Add(new(new Queue<long>(startingItems), operation, test));
        }
    }

    private static Func<long, long> CreateOperation(string[] temp, int number)
    {
        if (temp[1] == "*")
        {
            if (temp[2] == "old")
                return old => (old * old) % number;
            else
                return old => (old * long.Parse(temp[2])) % number;
        }
        else if (temp[1] == "+")
        {
            if (temp[2] == "old")
                return old => (old + old) % number;
            else
                return old => (old + long.Parse(temp[2])) % number;
        }

        return _ => 1L;
    }
}