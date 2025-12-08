using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day8;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var mapOfAntennas = SearchForAntennas(rawInput);
        
        var maxY = rawInput.Length;
        var maxX = rawInput[0].Length;

        
        return CalculateAntinodes(mapOfAntennas, maxX, maxY).Union(mapOfAntennas.SelectMany(x => x.Value)).Distinct().Count();
    }

    private static List<Position2D> CalculateAntinodes(Dictionary<char, List<Position2D>> mapOfAntennas, int maxX, int maxY)
    {
        var mapOfAntinodes = new List<Position2D>();
        foreach (var antennaPositions in mapOfAntennas.Values)
        {
            for (var i = 0; i < antennaPositions.Count; i++)
            {
                for (var j = 0; j < antennaPositions.Count; j++)
                {
                    if(i == j)
                        continue;
                    
                    var p1 = antennaPositions[i];
                    var p2 = antennaPositions[j];
                    
                    var p3 = CalculateAntinodePosition(p1, p2);

                    while (p3.IsInGrid(maxX, maxY))
                    {
                        mapOfAntinodes.Add(p3);
                        
                        var newP3 = CalculateAntinodePosition(p2, p3);
                        p2 = p3;
                        p3 = newP3;
                    }
                }
            }
        }
        
        return mapOfAntinodes;
    }

    private static Position2D CalculateAntinodePosition(Position2D p1, Position2D p2) 
        => Position2D.GetVector(p1, p2).CalculatePosition(p2);

    private static Dictionary<char, List<Position2D>> SearchForAntennas(char[][] rawInput)
    {
        var mapOfAntennas = new Dictionary<char, List<Position2D>>();
        for (var y = 0; y < rawInput.Length; y++)
        {
            for (var x = 0; x < rawInput[y].Length; x++)
            {
                if(rawInput[y][x] == '.')
                    continue;

                var position = new Position2D(x, y);
                if(mapOfAntennas.TryGetValue(rawInput[y][x], out var positions))
                    positions.Add(position);
                else
                    mapOfAntennas[rawInput[y][x]] = [position];
            }
        }
        
        return mapOfAntennas;
    }
}