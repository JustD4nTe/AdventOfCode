using AoC.Shared;

namespace AoC2025.Day11;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var devices = File.ReadAllLines(Input)
            .Select(x => x.Split(": "))
            .ToDictionary(x => x[0], x => x[1].Split(" ").ToArray());

        var deviceVisitCount = new Dictionary<string, int>();

        var q = new Queue<string>();
        q.Enqueue("you");
        
        do
        {
            var curr = q.Dequeue();
            var outputs = devices[curr];

            foreach (var output in outputs)
            {
                if (deviceVisitCount.TryGetValue(output, out int value))
                    deviceVisitCount[output] = value + 1;
                else
                    deviceVisitCount[output] = 1;

                if (output == "out")
                    continue;

                q.Enqueue(output);
            }
        }while (q.Count > 0);

        return deviceVisitCount["out"];
    }
}