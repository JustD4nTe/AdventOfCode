using AoC.Shared;

namespace AoC2024.Day23;

public class PartTwo(string input) : Solution(input)
{
    private readonly Dictionary<string, List<string>> _nodes = new();
    
    private readonly List<string> _result = [];

    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input).Select(x => x.Split("-").ToArray()).ToArray();

        foreach (var line in rawInput)
        {
            if (_nodes.TryGetValue(line[0], out var value1))
                value1.Add(line[1]);
            else
                _nodes[line[0]] = [line[1]];
            
            if (_nodes.TryGetValue(line[1], out var value2))
                value2.Add(line[0]);
            else
                _nodes[line[1]] = [line[0]];
        }

        BronKerbosch([], _nodes.Keys.ToList(), []);
        var final = _result.OrderByDescending(x => x.Length).First();
        Console.WriteLine(final);
        return final.Split(",").Length;
    }
    
    private void BronKerbosch(List<string> R, List<string> P, List<string> X)
    {
        if (P.Count == 0 && X.Count == 0) 
            _result.Add(string.Join(",", R.OrderBy(x => x)));

        foreach (var v in P.ToArray())
        {
            var newR = R.Append(v).ToList();
            var newP = P.Intersect(_nodes[v]).ToList();
            var newX = X.Intersect(_nodes[v]).ToList();
            
            BronKerbosch(newR, newP, newX);
            P.Remove(v);
            X.Add(v);
        }
    }
}