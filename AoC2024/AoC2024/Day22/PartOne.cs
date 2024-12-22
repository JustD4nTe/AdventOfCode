using AoC.Shared;

namespace AoC2024.Day22;

public class PartOne(string input) : Solution(input)
{
    private const int SecretNumberIteration = 2000;
    
    public override long Solve()
    {
        var initialSecretNumbers = File.ReadAllLines(Input).Select(long.Parse).ToArray();

        long sum = 0;
        
        foreach (var initialSecretNumber in initialSecretNumbers)
        {
            var secretNumber = initialSecretNumber;
            for (var i = 0; i < SecretNumberIteration; i++)
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
            }
            sum += secretNumber;
        }
        
        return sum;
    }
    
    private static long Mix(long secretNumber, long value) => secretNumber ^ value;
    private static long Prune(long secretNumber) => secretNumber % 16777216;
}