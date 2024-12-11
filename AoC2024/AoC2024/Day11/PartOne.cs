using System.Text;
using AoC.Shared;

namespace AoC2024.Day11;

public class PartOne(string input) : Solution(input)
{
    private const int NumberOfBlinks = 25;
    
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)[0].Split(" ").Select(ulong.Parse).ToArray();
        var stones = new LinkedList<ulong>(rawInput);

        for (var i = 0; i < NumberOfBlinks; i++)
        {
            var head = stones.First;
            do
            {
                if(head.Value == 0)
                {
                    head.Value = 1;
                    head = head!.Next;
                    continue;
                }

                var str = head.Value.ToString();
                
                if (str.Length % 2 == 0)
                {
                    var half = str.Length / 2;
                    var left = ulong.Parse(str[..half]);
                    var right = ulong.Parse(str[half..]);
                    
                    head.Value = left;
                    stones.AddAfter(head, right);
                    head = head.Next;
                }
                else
                {
                    head.Value *= 2024;
                }
                
                head = head!.Next;
            } while (head is not null);
        }
        
        return stones.Count;
    }
}