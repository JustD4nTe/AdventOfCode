using AoC.Shared;
using AoC.Shared.Enums;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day8;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var mapOfAntennas = SearchForAntennas(rawInput);
        
        var maxY = rawInput.Length;
        var maxX = rawInput[0].Length;

        return CalculateAntinodes(mapOfAntennas, maxX, maxY).Distinct().Count();
    }

    private static List<Position> CalculateAntinodes(Dictionary<char, List<Position>> mapOfAntennas, int maxX, int maxY)
    {
        var mapOfAntinodes = new List<Position>();
        foreach (var antennaPositions in mapOfAntennas.Values)
        {
            for (var i = 0; i < antennaPositions.Count; i++)
            {
                for (var j = 0; j < antennaPositions.Count; j++)
                {
                    if (i == j)
                        continue;

                    var p1 = antennaPositions[i];
                    var p2 = antennaPositions[j];

                    var v = Position.GetVector(p1, p2);
                    var p3 = v.CalculatePosition(p2);

                    if (p3.IsInGrid(maxX, maxY))
                        mapOfAntinodes.Add(p3);
                }
            }
        }
        
        return mapOfAntinodes;
    }

    private static Dictionary<char, List<Position>> SearchForAntennas(char[][] rawInput)
    {
        var mapOfAntennas = new Dictionary<char, List<Position>>();
        for (var y = 0; y < rawInput.Length; y++)
        {
            for (var x = 0; x < rawInput[y].Length; x++)
            {
                if(rawInput[y][x] == '.')
                    continue;

                var position = new Position(x, y);
                if(mapOfAntennas.TryGetValue(rawInput[y][x], out var positions))
                    positions.Add(position);
                else
                    mapOfAntennas[rawInput[y][x]] = [position];
            }
        }
        
        return mapOfAntennas;
    }
}