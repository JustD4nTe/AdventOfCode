using AoC.Shared;

namespace AoC2025.Day11;

public class PartTwo(string input) : Solution(input)
{
    private Dictionary<string, string[]> _devices = [];

    public override long Solve()
    {
        _devices = File.ReadAllLines(Input)
            .Select(x => x.Split(": "))
            .ToDictionary(x => x[0], x => x[1].Split(" ").ToArray());

        // export to GraphViz
        //Console.WriteLine();
        //foreach (var device in _devices)
        //{
        //    Console.WriteLine($"{device.Key} -> {{ {string.Join(" ", device.Value)} }}");
        //}

        // well...at least it works
        var a = Pathfinding("svr", "fft", ["njx", "fxz", "kmc", "opq", "amt"]);
        Console.WriteLine($"a: {a}");
        var b = Pathfinding("fft", "dac", ["tsp", "pvf", "lym", "hky", "yzb", "nsa","dio", "ybi", "ibr", "xuu", "xlo", "poa", "you", "vkz", "iqd"]);
        Console.WriteLine($"b: {b}");
        var c = Pathfinding("dac", "out", []);
        Console.WriteLine($"c: {c}");
        return a * b * c;
    }

    private long Pathfinding(string start, string end, string[] avoid)
    {
        var deviceVisitCount = new Dictionary<string, int>();

        var q = new Queue<string>();
        q.Enqueue(start);

        do
        {
            var curr = q.Dequeue();
            var outputs = _devices[curr];

            foreach (var output in outputs)
            {
                if (avoid.Contains(output))
                    continue;

                if (deviceVisitCount.TryGetValue(output, out int value))
                    deviceVisitCount[output] = value + 1;
                else
                    deviceVisitCount[output] = 1;

                if (output == end)
                    continue;

                q.Enqueue(output);
            }
        } while (q.Count > 0);

        return deviceVisitCount[end];
    }
}