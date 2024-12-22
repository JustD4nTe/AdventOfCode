using AoC.Shared;

namespace AoC2024.Day22;

public class PartTwo(string input) : Solution(input)
{
    private const int SecretNumberIteration = 2000;

    public override long Solve()
    {
        var initialSecretNumbers = File.ReadAllLines(Input).Select(long.Parse).ToArray();

        var buff = new Dictionary<ChangeKey, long>();

        foreach (var initialSecretNumber in initialSecretNumbers)
        {
            var secretNumber = initialSecretNumber;

            var bananas = new long[2000];
            bananas[0] = secretNumber % 10;

            var changeSequence = new LinkedList<long>();
            var usedChanges = new HashSet<ChangeKey>();

            for (var i = 1; i < SecretNumberIteration; i++)
            {
                secretNumber = GenerateNewSecretNumber(secretNumber);

                bananas[i] = secretNumber % 10;

                if (changeSequence.Count == 4)
                    changeSequence.RemoveFirst();

                changeSequence.AddLast(bananas[i] - bananas[i - 1]);

                if (changeSequence.Count < 4) 
                    continue;
                
                var changeKey = new ChangeKey(changeSequence.ToArray());
                
                if (!usedChanges.Add(changeKey))
                    continue;
                    
                if (buff.ContainsKey(changeKey))
                    buff[changeKey] += bananas[i];
                else 
                    buff[changeKey] = bananas[i];
            }
        }
        
        return  buff.Max(x => x.Value);
    }

    private record ChangeKey
    {
        public long ChangeOne { get; init; }
        public long ChangeTwo { get; init; }
        public long ChangeThree { get; init; }
        public long ChangeFour { get; init; }

        public ChangeKey(long[] arr)
        {
            ChangeOne = arr[0];
            ChangeTwo = arr[1];
            ChangeThree = arr[2];
            ChangeFour = arr[3];
        }
    }
    
    private static long GenerateNewSecretNumber(long secretNumber)
    {
        var result = secretNumber * 64;
        secretNumber = Mix(secretNumber, result);
        secretNumber = Prune(secretNumber);

        result = secretNumber / 32;
        secretNumber = Mix(secretNumber, result);
        secretNumber = Prune(secretNumber);

        result = secretNumber * 2048;
        secretNumber = Mix(secretNumber, result);
        secretNumber = Prune(secretNumber);
        return secretNumber;
    }

    private static long Mix(long secretNumber, long value) => secretNumber ^ value;
    private static long Prune(long secretNumber) => secretNumber % 16777216;
}