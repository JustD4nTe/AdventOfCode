using System.Collections.Specialized;
using AoC.Shared;

namespace AoC2024.Day23;

public class PartOne(string input) : Solution(input)
{
    private readonly Dictionary<string, List<string>> _nodes = new();

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

        var namesWithT = _nodes.Keys.Where(x => x.StartsWith('t')).ToArray();
        var result = new List<string>();
        
        foreach (var nameWithT in namesWithT)
        {
            foreach (var secondNode in _nodes[nameWithT])
            {
                foreach (var thirdNode in _nodes[secondNode].Where(x =>  x != nameWithT))
                {
                    if (!_nodes[thirdNode].Contains(nameWithT))
                        continue;
                    
                    string[] newRes = [nameWithT, secondNode, thirdNode];
                    result.Add(string.Join(", ", newRes.OrderBy(x => x).ToArray()));
                }
            }
        }
        return result.Distinct().Count();
    }
}