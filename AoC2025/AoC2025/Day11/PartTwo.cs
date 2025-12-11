using AoC.Shared;

namespace AoC2025.Day11;

public class PartTwo(string input) : Solution(input)
{
    private readonly Dictionary<string, long> _cache = [];
    private Dictionary<string, string[]> _devices = [];

    public override long Solve()
    {
        _devices = File.ReadAllLines(Input)
            .Select(x => x.Split(": "))
            .ToDictionary(x => x[0], x => x[1].Split(" ").ToArray());

        long a = Pathfinding("svr", "fft");
        _cache.Clear();
        long b = Pathfinding("fft", "dac");
        _cache.Clear();
        long c = Pathfinding("dac", "out");
        return a * b * c;
    }

    private long Pathfinding(string start, string end)
    {
        if (_cache.ContainsKey(start))
            return _cache[start];

        if (start == end)
        {
            _cache[start] = 1;
        }
        else
        {
            var result = 0L;
            
            foreach (var nextStart in _devices.GetValueOrDefault(start) ?? [])
            {
                result += Pathfinding(nextStart, end);
            }

            _cache[start] = result;
        }

        return _cache[start];
    }
}