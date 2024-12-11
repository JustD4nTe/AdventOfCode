using System.Text;
using AoC.Shared;

namespace AoC2024.Day11;

public class PartTwo(string input) : Solution(input)
{
    private const int NumberOfBlinks = 75;
    
    public override long Solve()
    {
        var stones = File.ReadAllLines(Input)[0]
            .Split(" ")
            .Select(ulong.Parse)
            .ToDictionary(x => x, x => (ulong)1);

        var buff = new Dictionary<ulong, ulong>();
        for (var i = 0; i < NumberOfBlinks; i++)
        {
            buff.Clear();
            foreach(var stoneId in stones.Keys)
            {
                if(stoneId == 0)
                {
                    if(buff.ContainsKey(1))
                        buff[1] += stones[stoneId];
                    else
                        buff[1] = stones[stoneId];
                    
                    continue;
                }
                
                var strStoneId = stoneId.ToString();
                
                if (strStoneId.Length % 2 == 0)
                {
                    var halfStoneId = strStoneId.Length / 2;
                    var leftStoneId = ulong.Parse(strStoneId[..halfStoneId]);
                    var rightStoneId = ulong.Parse(strStoneId[halfStoneId..]);
                    
                    if(buff.ContainsKey(leftStoneId))
                        buff[leftStoneId] += stones[stoneId];
                    else
                        buff[leftStoneId] = stones[stoneId];
                    
                    if(buff.ContainsKey(rightStoneId))
                        buff[rightStoneId] += stones[stoneId];
                    else
                        buff[rightStoneId] = stones[stoneId];
                }
                else
                {
                    var newStoneId = stoneId * 2024;
                    
                    if(buff.ContainsKey(newStoneId))
                        buff[newStoneId] += stones[stoneId];
                    else
                        buff[newStoneId] = stones[stoneId];
                }
            }
            stones.Clear();
            stones = buff.ToDictionary();
        }

        var sum = buff.Values
            .Select(x => x)
            .Aggregate((x, y) => x + y);

        return (long)sum;
    }
}