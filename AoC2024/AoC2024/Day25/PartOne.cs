using System.Collections.Specialized;
using AoC.Shared;

namespace AoC2024.Day25;

public class PartOne(string input) : Solution(input)
{ 
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n").Select(x => x.Split("\r\n").ToArray()).ToArray();
        
        var locks = new List<Schematic>();
        var keys = new List<Schematic>();
        
        foreach (var input in rawInput)
        {
            if (input[0] == "#####")
                locks.Add(InitSchematics(input));
            else
                keys.Add(InitSchematics(input));
        }

        return locks.Sum(x => keys.Count(x.CheckFit));
    }

    private static Schematic InitSchematics(string[] input)
    {
        var pins = new int[5];
                
        for (var i = 0; i < input[0].Length; i++)
            pins[i] = input.Count(x => x[i] == '#') - 1;
                
        return new Schematic(pins);
    }

    private record Schematic(int[] Pins)
    {
        public bool CheckFit(Schematic other) 
            => !Pins.Where((t, i) => t + other.Pins[i] > 5).Any();
    }
}